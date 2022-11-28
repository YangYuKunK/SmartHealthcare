<template>
  <div style="border: 1px solid #ccc;">
    <Toolbar style="border-bottom: 1px solid #ccc" :editor="editor" :defaultConfig="toolbarConfig" :mode="mode" />
    <Editor @onCreated="onCreated" @onChange="onChange" @onDestroyed="onDestroyed" @onMaxLength="onMaxLength"
      @onFocus="onFocus" @onBlur="onBlur" @customAlert="customAlert" @customPaste="customPaste" />
  </div>
</template>
<!-- @customAlert="customAlert" -->
<script>
import Vue from 'vue'
import { Editor, Toolbar } from '@wangeditor/editor-for-vue'
import { Url } from 'url'
import { SlateElement } from '@wangeditor/editor'
import Axios from 'axios'

export default Vue.extend({
  components: { Editor, Toolbar },
  data() {
    return {
      editor: null,
      html: '<p>hello</p>',
      toolbarConfig: {},
      editorConfig: {
        placeholder: '请输入内容...',
        // autoFocus: false,
        // 所有的菜单配置，都要在 MENU_CONF 属性下
        MENU_CONF: {
          uploadImage: {
            // 后端上传地址，必填
            server: "/api/upload/image",
            // form-data fieldName，后端接口参数名称，默认值wangeditor-uploaded-image
            fieldName: "file",
            // 1M，单个文件的最大体积限制，默认为 2M
            maxFileSize: 1 * 1024 * 1024,
            // 最多可上传几个文件，默认为 100
            maxNumberOfFiles: 10,
            // 选择文件时的类型限制，默认为 ['image/*'] 。如不想限制，则设置为 []
            allowedFileTypes: ['image/*'],
            // 15 秒，超时时间，默认为 10 秒
            timeout: 15 * 1000,
            // 自定义上传参数，例如传递验证的 token 等。参数会被添加到 formData 中，一起上传到服务端。
            // meta: {
            //     token: 'xxx',
            //     otherKey: 'yyy'
            // },
            // 将 meta 拼接到 url 参数中，默认 false
            // metaWithUrl: false,
            // 自定义增加 http  header
            // headers: {
            //     Accept: 'text/x-json',
            //     otherKey: 'xxx'
            // },
            // 跨域是否传递 cookie ，默认为 false
            // withCredentials: false,
          },
          uploadVideo: {
            // 后端上传地址，必填
            server: "/api/upload/video",
            // form-data fieldName，后端接口参数名称，默认值wangeditor-uploaded-video
            fieldName: "file",
            // 5M，文件大小限制，默认10M
            maxFileSize: 5 * 1024 * 1024,
            // 最多可上传几个文件，默认为 5
            maxNumberOfFiles: 3,
            // 选择文件时的类型限制，默认为 ['video/*'] 。如不想限制，则设置为 []
            allowedFileTypes: ['video/*'],
            // 15 秒，超时时间，默认为 30 秒
            timeout: 15 * 1000,
            // 自定义上传参数，例如传递验证的 token 等。参数会被添加到 formData 中，一起上传到服务端。
            // meta: {
            //     token: 'xxx',
            //     otherKey: 'yyy'
            // },
            // 将 meta 拼接到 url 参数中，默认 false
            // metaWithUrl: false,
            // 自定义增加 http  header
            // headers: {
            //     Accept: 'text/x-json',
            //     otherKey: 'xxx'
            // },
            // 跨域是否传递 cookie ，默认为 false
            // withCredentials: false,
          }
        }
      },
      mode: 'simple'
    
      // mode: 'default', // or 'simple'
    }
  },
  methods: {
    onCreated(editor) {
      this.editor = Object.seal(editor) // 一定要用 Object.seal() ，否则会报错
      console.log('onCreated', editor)
    },
    onChange(editor) { console.log('onChange', editor.children) },
    onDestroyed(editor) { console.log('onDestroyed', editor) },
    onMaxLength(editor) { console.log('onMaxLength', editor) },
    onFocus(editor) { console.log('onFocus', editor) },
    onBlur(editor) { console.log('onBlur', editor) },
    customAlert(info, type) { window.alert(`customAlert in Vue demo\n${type}:\n${info}`) },
    customPaste(editor, event, callback) {
      console.log('ClipboardEvent 粘贴事件对象', event)
      // editor.getMenuConfig('uploadImage')

      // 自定义插入内容
      editor.insertText('xxx')
      // 返回 false ，阻止默认粘贴行为
      event.preventDefault()
      callback(false) // 返回值（注意，vue 事件的返回值，不能用 return）
    },

  },
  mounted() {
    // 模拟 ajax 请求，异步渲染编辑器
    setTimeout(() => {
      this.html = '<p>模拟 Ajax 异步设置内容 HTML</p>'
    }, 1500),
      // 配置服务器端地址 upload:上传图片地址
      // editor.customConfig.uploadImgServer = 'https://localhost:44388/api/good/UpLoad',
      editorConfig.MENU_CONF['uploadImage'] = {
        // server: 'https://localhost:44388/api/good/UpLoad',
        // 自定义上传
        update(file, insertFn) {
          console.log("test")
          Axios({
            url: 'https://localhost:44388/api/good/UpLoad',
            method:'post'
          }).then(ex => { 
            console.log(ex)
            // insertFn('http://' + ex.Location, file.name, 'http://' + res.Location)
          })
          // file 即选中的文件
          // 自己实现上传，并得到图片 url alt href
          // let name = md5(file.name);
          // let suffix = file.type.split("/")[1];
          // name = name + '.' + suffix;
          // uploadFile(name, file).then(res => {
          //   if (res.statusCode == 200) {
          //     // 最后插入图片
          //     console.log(res);
          // insertFn('http://' + res.Location, file.name, 'http://' + res.Location)
          //   } else { }
          // })
        },
        onBeforeUpload(file) {    // JS 语法
          // file 选中的文件，格式如 { key: file }
          console.log(file)
          return file
        },
        // 上传进度的回调函数
        onProgress(progress) {       // JS 语法
          // progress 是 0-100 的数字
          console.log('progress', progress)
        },

        // 单个文件上传成功之后
        onSuccess(file, res) {          // JS 语法
          console.log(`${file.name} 上传成功`, res)
        },

        // 单个文件上传失败
        onFailed(file, res) {           // JS 语法
          console.log(`${file.name} 上传失败`, res)
        },

        // 上传错误，或者触发 timeout 超时
        onError(file, err, res) {               // JS 语法
          console.log(`${file.name} 上传出错`, err, res)
        },
      }
  },
  beforeDestroy() {
    const editor = this.editor
    if (editor == null) return
    editor.destroy() // 组件销毁时，及时销毁编辑器
  }
})

</script>

<style src="@wangeditor/editor/dist/css/style.css">

</style>