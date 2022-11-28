<template>
    <div class="userseindex">
        <!-- 搜索条件 -->
        <el-row :gutter="20" class="userseindex-queryInfo">
            <!-- 用户姓名搜索 -->
            <el-col :xs="8" :sm="6" :md="6" :lg="4" :xl="4">
                <el-input class="userseindex-queryInfo-li" v-model="queryInfo.name" clearable size="small"
                    placeholder="请输入用户姓名"></el-input>
            </el-col>
            <!-- 用户手机号搜索 -->
            <el-col :xs="8" :sm="6" :md="6" :lg="4" :xl="4">
                <el-input class="userseindex-queryInfo-li" v-model="queryInfo.phone" clearable size="small"
                    placeholder="请输入用户手机号"></el-input>
            </el-col>
            <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
                <el-button type="primary" class="userseindex-queryInfo-li" @click="getuser(queryInfo)" size="small">搜索
                </el-button>
            </el-col>
            <!-- 返回用户列表 -->
            <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
                <el-button type="success" class="userseindex-queryInfo-li" size="small" @click="showuser">返回用户列表
                </el-button>
            </el-col>
        </el-row>
        <!-- 检索结果 -->
        <el-row :gutter="20" class="userseindex-list">
            <el-col :span="24">
                <el-table :data="tableData" border size='small' style="width: 100%">
                    <el-table-column prop="userId" type="index" label="用户序号">
                    </el-table-column>
                    <el-table-column label="用户头像" width="150">
                        <template slot-scope="scope">
                            <img :src="scope.row.userAvatar" height="100">
                        </template>
                    </el-table-column>
                    <el-table-column prop="userName" label="用户姓名">
                    </el-table-column>
                    <el-table-column prop="userSex" label="用户性别">
                        <template slot-scope="scope">
                            {{ options1[scope.row.userSex]['label'] }}
                        </template>
                    </el-table-column>
                    <el-table-column prop="userAge" label="用户年龄">
                    </el-table-column>
                    <el-table-column prop="userPhone" label="用户手机号">
                    </el-table-column>
                    <el-table-column prop="userAdmin" label="用户账号">
                    </el-table-column>
                    <el-table-column prop="userPass" label="用户密码">
                    </el-table-column>
                    <el-table-column prop="userBalance" label="用户余额">
                    </el-table-column>
                    <el-table-column label="操作">
                        <template slot-scope="scope">
                            <el-button size="mini" @click="UptUserInfo(scope.row)">编辑用户</el-button>
                            <el-button size="mini" type="danger" @click="deleteuser(scope.row)">恢复</el-button>
                        </template>
                    </el-table-column>
                </el-table>
            </el-col>
        </el-row>
        <!-- 分页 -->
        <el-row :gutter="20" class="userseindex-list">
            <el-col :span="24" class="userseindex-page-box">
                <el-pagination :hide-on-single-page="true" @size-change="handleSizeChange"
                    @current-change="handleCurrentChange" :current-page="queryInfo.page" :page-sizes="[10, 20, 50, 100]"
                    :page-size="queryInfo.pageSize" layout="total, sizes, prev, pager, next, jumper" :total="400">
                </el-pagination>
            </el-col>
        </el-row>
        <!-- 编辑用户弹出层 -->
        <el-dialog title="编辑用户" :visible.sync="UptUserShwo">
            <el-form :model="userFrom" :rules="ruleGood" ref="userFrom" label-width="120px" class="demo-ruleForm">
                <el-form-item label="用户姓名" prop="userName">
                    <el-input v-model="userFrom.userName" placeholder="请输入用户姓名"></el-input>
                </el-form-item>
                <el-form-item label="登录账号" prop="userAdmin">
                    <el-input v-model="userFrom.userAdmin" placeholder="请输入登录账号"></el-input>
                </el-form-item>
                <el-form-item label="登录密码" prop="userPass">
                    <el-input v-model="userFrom.userPass" placeholder="请输入登录密码"></el-input>
                </el-form-item>
                <el-form-item label="用户年龄" prop="userAge">
                    <el-input v-model="userFrom.userAge" placeholder="请输入用户年龄"></el-input>
                </el-form-item>
                <!-- <el-form-item label="用户性别" prop="usersex">
                    <el-radio-group v-model="userFrom.usersex">
                    <el-radio label="男" value="1"></el-radio>
                    <el-radio label="女" value="0"></el-radio>
                    </el-radio-group>
                </el-form-item> -->
                <el-form-item label="用户性别" prop="userSex">
                    <el-radio-group v-model="userFrom.userSex" size="medium">
                        <el-radio v-for="(item, index) in usersexfrom" :key="index" :label="item.value"
                            :disabled="item.disabled">{{ item.label }}</el-radio>
                    </el-radio-group>
                </el-form-item>
                <el-form-item label="身份证号" prop="userIDCard">
                    <el-input v-model="userFrom.userIDCard" placeholder="请输入身份证号"></el-input>
                </el-form-item>
                <el-form-item label="手机号" prop="userPhone">
                    <el-input v-model="userFrom.userPhone" placeholder="请输入手机号"></el-input>
                </el-form-item>
                <el-form-item label="用户编号" prop="userNumber">
                    <el-input v-model="userFrom.userNumber" placeholder="用户编号"></el-input>
                </el-form-item>
                <el-form-item label="头像" prop="userAvatar">
                    <el-input v-model="userFrom.userAvatar" placeholder="请选择头像"></el-input>
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
            </el-form>
            <div slot="footer" class="dialog-footer">
                <el-button type="primary" @click="UptadaUserInfo('userFrom')">提 交</el-button>
            </div>
        </el-dialog>
    </div>

</template>
  
<script>
import Axios from 'axios'
export default {
    created() {
        this.fun()
    },
    data() {
        return {
            //编辑弹框
            UptUserShwo: false,
            userFrom: {
                pick: 8,
                creationPerson: "杨宇坤",
                creationTime: "2022-11-11T00:00:00",
                deletePerson: "",
                deletetime: "0001-01-01T00:00:00",
                modificationPerson: "",
                modificationTime: "0001-01-01T00:00:00",
                userAddress: "上海奉贤",
                userAdmin: "17732072862",
                userAge: 22,
                userAvatar: "",
                userBalance: 10000,
                userDeleteState: 0,
                userHobby: "看小说",
                userIDCard: "123456789123456789",
                userId: 4,
                userName: "杨宇坤",
                userNumber: "user_2003_0006",
                userPass: "yang",
                userPhone: "12345678912",
                userSex: 1
            },
            queryInfo: {
                name: '',
                phone: '',
                type: '',
                page: 1,
                pageSize: 10,
                pagetotal: 2
            },
            ruleGood: {

            },
            usersexfrom: [{
                "label": "男",
                "value": 1
            }, {
                "label": "女",
                "value": 0
            }],
            options: [
                {
                    label: 0,
                    value: '女'
                },
                {
                    label: 1,
                    value: '男'
                }
            ],
            options1: [
                {
                    label: "女",
                    value: "0"
                },
                {
                    label: "男",
                    value: "1"
                }
            ],
            tableData: []
        }
    },
    methods: {
        fun() {
            Axios({
                url: 'https://localhost:44388/api/User/GetDeleteUserList',
                method: 'get'
            }).then(ex => {
                console.log(ex.data.data.length)
                this.queryInfo.pagetotal = ex.data.data.length
                this.tableData = ex.data.data
                // console.log(this.tableData.length)
                // console.log(this,)
            })
        },
        //编辑弹框
        UptUserInfo(row) {
            console.log(row)
            this.userFrom = row;
            this.UptUserShwo = true
        },
        //编辑用户信息
        UptadaUserInfo() {
            console.log(this.userFrom)
            Axios({
                url: 'https://localhost:44388/api/User/UpdateUserInfo',
                data: this.userFrom,
                method: 'put'
            }).then(ex => {
                if (ex.data.data > 0) {
                    this.$message({
                        message: '恭喜你，编辑用户成功！',
                        type: 'success'
                    }, { TimeRanges: 2000 });
                    setInterval(() => {
                        this.$router.go(0);
                    }, 2000);
                }
                else {
                    this.$message.error('很遗憾，编辑用户失败！');
                }
            })
        },
        //搜索
        getuser(queryInfo) {
            Axios({
                url: 'https://localhost:44388/api/User/GetDeleteUserListPhoneAndName?userphone=' + queryInfo.phone + '&username=' + queryInfo.name,
                method: 'get'
            }).then(ex => {
                console.log(ex.data.data)
                this.tableData = ex.data.data
            })
        },
        handleSizeChange() {

        },
        handleCurrentChange() {

        },
        //返回用户列表
        showuser() {
            this.$router.push('/Userse/index')
        },
        //恢复用户
        deleteuser(row) {
            console.log(row.userId)
            this.$confirm('确认将该用户恢复么, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                Axios({
                    url: 'https://localhost:44388/api/User/UpdateDeleteUser?userid=' + row.userId,
                    method: 'put'
                }).then(ex => {
                    if (ex.data.data > 0) {
                        this.$message({
                            message: '恭喜你，恢复该用户成功！',
                            type: 'success',

                        });
                    } else {
                        this.$message.error('很遗憾，恢复该用户失败！');
                    }
                    this.fun()
                })
            }).catch(() => {
                this.$message({
                    type: 'info',
                    message: '已取消霍夫'
                });
            });
        },
    }
}
</script>
  
  <!--样式-->
<style scoped>
.userseindex {
    width: 100%;
    min-height: 100%;
    padding: 15px;
    box-sizing: border-box;
}

/* 搜索 */
.userseindex-queryInfo {
    margin-bottom: 10px;
}

.userseindex-queryInfo-li {
    width: 100%;
    height: auto;
}

/* 列表 */
.userseindex-list {
    width: 100%;
    height: auto;
    margin-bottom: 20px;
}

/* 分页 */
.userseindex-page-box {
    width: 100%;
    height: auto;
    display: flex;
    justify-content: flex-end;
}
</style>