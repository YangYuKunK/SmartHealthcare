<template>
  <div class="FromGood">
    <el-form :model="goodFrom" :rules="ruleGood" ref="goodFrom" label-width="120px" class="demo-ruleForm">
      <el-form-item label="当前图片" :label-width="formLabelWidth" prop="name">
        <el-upload class="upload-demo" :action="fangwen" :file-list="imgadd" :on-success="handleChange"
          list-type="picture">
          <el-button size="small" type="primary">点击上传</el-button>
          <div slot="tip" class="el-upload__tip">只能上传jpg/png文件,且不超过500kb</div>
        </el-upload>
      </el-form-item>
      <el-form-item label="商品名称" prop="goodsName">
        <el-input v-model="goodFrom.goodsName" placeholder="请输入商品名称"></el-input>
      </el-form-item>
      <el-form-item label="商品单价" prop="GoodsPrice">
        <el-input-number v-model="goodFrom.GoodsPrice" :precision="2" :step="0.1" :max="10000" :min="0.1"
          placeholder="请输入商品单价"></el-input-number>
      </el-form-item>
      <el-form-item label="商品数量" prop="GoodsNumber">
        <el-input v-model="goodFrom.GoodsNumber" placeholder="请输入商品数量"></el-input>
      </el-form-item>
      <el-form-item label="商品简介" prop="GoodsDescription">
        <el-input v-model="goodFrom.GoodsDescription" placeholder="请输入商品简介"></el-input>
      </el-form-item>
      <el-form-item label="商品规格" prop="GoodsSpecification">
        <el-input v-model="goodFrom.GoodsSpecification" placeholder="请输入商品规格"></el-input>
      </el-form-item>
      <el-form-item label="商品售后服务" prop="GoodsServe">
        <el-input v-model="goodFrom.GoodsServe" placeholder="请输入商品售后服务"></el-input>
      </el-form-item>
      <!-- <el-form-item label="商品类型" prop="TypeId">
        <el-input v-model="goodFrom.TypeId" placeholder="请输入商品类型"></el-input>
      </el-form-item> -->
      <el-form-item label="商品类型" prop="TypeId">
        <el-select class="goodsindex-queryInfo-li" v-model="goodFrom.TypeId" size="small" clearable
          placeholder="请输入商品类型">
          <el-option v-for="item in options" :key="item.typeId" :label="item.typeName" :value="item.typeId">
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="submitForm('goodFrom')">立即添加</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import Axios from 'axios';
export default {
  data() {
    return {
      //上传文件网址
      fangwen: "https://localhost:44388/api/good/UpLoad",
      imgadd: [],
      goodFrom: {
        pick: 8
      },
      ruleGood: {

      },
      options: [],
      dialogImageUrl: '',
      dialogVisible: false,
      formLabelWidth: '120px',
    }
  },
  created() {
    this.fun()
  },
  methods: {
    fun() {
      //获取商品分类信息
      Axios({
        url: 'https://localhost:44388/api/GoodType/GetGoodTypeList',
        method: 'get'
      }).then(ex => {
        this.options = ex.data.data
      })
    },
    submitForm() {
      console.log(this.goodFrom)
      Axios({
        url: 'https://localhost:44388/api/good/InsertGoodInfo',
        data: this.goodFrom,
        method: 'post'
      }).then(ex => {
        if (ex.data.data > 0) {
          this.$message({
            message: '恭喜你，商品添加成功！',
            type: 'success'
          });
          this.$router.push('/goods/Index')
        } else {
          this.$message.error('很遗憾，商品添加失败！');
        }
      })
    },
    handleRemove(file, fileList) {
      console.log(file, fileList);
    },
    handlePictureCardPreview(file) {
      this.dialogImageUrl = file.url;
      this.dialogVisible = true;
    },
    handleChange(file) {
      console.log(file)
      this.goodFrom.GoodsImg = file.newFileName;
    },
  }
}
</script>


<style scoped>

.FromGood {
  width: 100%;
  min-height: 100%;
  padding: 15px;
  box-sizing: border-box;
}
</style>