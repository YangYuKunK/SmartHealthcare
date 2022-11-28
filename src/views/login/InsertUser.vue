<template>
    <div class="AddUser">
        <el-form :model="userFrom" :rules="ruleGood" ref="userFrom" label-width="120px" class="demo-ruleForm">
            <el-form-item label="当前图片" :label-width="formLabelWidth" prop="name">
                <el-upload class="upload-demo" :action="fangwen" :file-list="imgadd" :on-success="handleChange"
                    list-type="picture">
                    <el-button size="small" type="primary">点击上传</el-button>
                    <div slot="tip" class="el-upload__tip">只能上传jpg/png文件,且不超过500kb</div>
                </el-upload>
            </el-form-item>
            <el-form-item label="用户姓名" prop="userName">
                <el-input v-model="userFrom.userName" placeholder="请输入用户姓名"></el-input>
            </el-form-item>
            <el-form-item label="登录账号" prop="userAdmin">
                <el-input v-model="userFrom.userAdmin" placeholder="请输入登录账号"></el-input>
            </el-form-item>
            <el-form-item label="登录密码" prop="userpass">
                <el-input v-model="userFrom.userpass" placeholder="请输入登录密码"></el-input>
            </el-form-item>
            <el-form-item label="用户年龄" prop="userage">
                <el-input v-model="userFrom.userage" placeholder="请输入用户年龄"></el-input>
            </el-form-item>
            <el-form-item label="用户性别" prop="usersex">
                <el-radio-group v-model="userFrom.usersex" size="medium">
                    <el-radio v-for="(item, index) in usersexfrom" :key="index" :label="item.value"
                        :disabled="item.disabled">{{ item.label }}</el-radio>
                </el-radio-group>
            </el-form-item>
            <el-form-item label="身份证号" prop="userIdCard">
                <el-input v-model="userFrom.userIdCard" placeholder="请输入身份证号"></el-input>
            </el-form-item>
            <el-form-item label="手机号" prop="userPhone">
                <el-input v-model="userFrom.userPhone" placeholder="请输入手机号"></el-input>
            </el-form-item>
            <el-form-item label="用户编号" prop="userNumber">
                <el-input v-model="userFrom.userNumber" placeholder="用户编号"></el-input>
            </el-form-item>
            <el-form-item label="用户爱好" prop="userHobby">
                <el-input v-model="userFrom.userHobby" placeholder="请输入爱好"></el-input>
            </el-form-item>
            <el-form-item label="用户余额" prop="userBalance">
                <el-input-number v-model="userFrom.userBalance" :precision="2" :step="0.1" :max="100000" :min="0.1"
                    placeholder="请选择用户余额"></el-input-number>
            </el-form-item>

            <el-form-item label="用户地址" prop="userAddress">
                <el-input v-model="userFrom.userAddress" placeholder="请输入用户地址"></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="submitForm('userFrom')" :addding="addding">立即添加</el-button>
                <el-button type="primary" @click="tologin" :addding="addding">返回</el-button>
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
            fangwen: "https://localhost:44388/api/User/UpLoad",
            imgadd: [],
            userFrom: {
                pick: 8
            },
            ruleGood: {

            },
            dialogImageUrl: '',
            dialogVisible: false,
            usersexfrom: [{
                "label": "男",
                "value": 1
            }, {
                "label": "女",
                "value": 0
            }],
            formLabelWidth: '120px',
        }
    },
    methods: {
        submitForm() {
            Axios({
                url: 'https://localhost:44388/api/User/CreateUserInfo',
                data: this.userFrom,
                method: 'post'
            }).then(ex => {
                if (ex.data.data > 0) {
                    this.$message({
                        message: '恭喜你，注册成功！',
                        type: 'success'
                    });
                    this.addding = true
                    this.$router.push({
                        path: '/login'
                    })
                } else {
                    this.$message.error('很遗憾，注册失败！');
                }
            })
        },
        tologin() {
            this.$router.push({
                path: '/login'
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
            this.userFrom.userAvatar = file.newFileName;
        },
    }
}
</script>
  
<style scoped>
.AddUser {
    width: 100%;
    min-height: 100%;
    padding: 15px;
    box-sizing: border-box;
}
</style>