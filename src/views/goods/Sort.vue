<template>
  <div class="sort">
    <el-row :gutter="20">
      <el-col :xs="24" :sm="24" :md="24" :lg="12" :xl="12">
        <!-- 添加按钮 -->
        <el-row class="sort-one-head">
          <el-col :span="6">
            <div class="sort-one-name">分类</div>
          </el-col>
          <el-col :xs="12" :sm="8" :md="6" :lg="4" :xl="4" class="sort-one-add">
            <el-button type="primary" class="sort-one-add-submit" size="small" @click="addOneSort"> 添加分类</el-button>
          </el-col>
        </el-row>
      </el-col>
    </el-row>
    <!-- 分类列表 -->
    <el-row :gutter="20" class="sort-one-list">
      <el-col :span="24">
        <el-table :data="tableDataone" border size='small' style="width: 100%">
          <el-table-column prop="typeId" type="index" label="分类序号">
          </el-table-column>
          <el-table-column label="分类图片" width="150">
            <template slot-scope="scope">
              <img :src="scope.row.typeImg" height="100">
            </template>
          </el-table-column>
          <el-table-column prop="typeName" label="分类名称">
          </el-table-column>
          <el-table-column prop="goodsTypeNumber" label="分类数量">
          </el-table-column>
          <el-table-column label="操作">
            <template slot-scope="scope">
              <el-button size="mini" @click="uptone(scope.row)">编辑</el-button>
              <el-button size="mini" type="danger" @click="delone(scope.row)">删除</el-button>
            </template>
          </el-table-column>
        </el-table>
      </el-col>
    </el-row>
    <!-- 分页 -->
    <el-row class="sort-one-page">
      <el-col :span="24" class="sort-one-page-line">
        <el-pagination :hide-on-single-page="true" background layout="prev, pager, next" :total="1000">
        </el-pagination>
      </el-col>
    </el-row>
    <!-- 新增分类弹出层 -->
    <el-dialog title="添加分类" :visible.sync="oneSortShwo">
      <el-form :model="oneSortForm" ref="oneSortForm">
        <el-form-item label="当前图片" :label-width="formLabelWidth" prop="typeImg">
          <el-upload class="upload-demo" :action="fangwen" :file-list="imgadd" :on-success="handleChange"
            list-type="picture">
            <el-button size="small" type="primary">点击上传</el-button>
            <div slot="tip" class="el-upload__tip">只能上传jpg/png文件,且不超过500kb</div>
          </el-upload>
        </el-form-item>
        <el-form-item label="分类名称" :label-width="typeName" prop="typeName">
          <el-input v-model="oneSortForm.typeName" autocomplete="off" placeholder="请输入分类名称"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="oneSortSUbmit('oneSortForm')">提 交</el-button>
      </div>
    </el-dialog>
    <!-- 编辑分类弹出层 -->
    <el-dialog title="编辑分类" :visible.sync="uptdatasort">
      <el-form :model="tableDataone" ref="tableDataone" label-width="120px" class="demo-ruleForm">
        <el-form-item label="当前图片" :label-width="formLabelWidth" prop="typeImg">
          <el-upload class="upload-demo" :action="fangwen" :file-list="imgadd" :on-success="handleChange"
            list-type="picture">
            <el-button size="small" type="primary">点击上传</el-button>
            <div slot="tip" class="el-upload__tip">只能上传jpg/png文件,且不超过500kb</div>
          </el-upload>
        </el-form-item>
        <el-form-item label="分类名称" prop="typeName">
          <el-input v-model="tableDataone.typeName" placeholder="请输入商品名称"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="updatesort('tableDataone')">提 交</el-button>
      </div>
    </el-dialog>
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
      //分类显示
      tableDataone: [],
      // 添加分类
      oneSortShwo: false,
      oneSortForm: {},
      // 分类
      uptdatasort: false,
      formLabelWidth: '120px',
    }
  },
  created() {
    this.fun();
  },
  methods: {
    //分类显示
    fun() {
      Axios({
        url: 'https://localhost:44388/api/GoodType/GetGoodTypeList',
        method: 'get'
      }).then(ex => {
        this.tableDataone = ex.data.data
      })
    },
    addOneSort() {
      this.oneSortShwo = true
    },
    uptone(row) {
      console.log(row)
      this.tableDataone = row;
      this.uptdatasort = true
    },
    //插入图片
    handleChange(file) {
      console.log(file)
      this.oneSortForm.typeImg = file.newFileName;
    },
    //分类添加
    oneSortSUbmit() {
      console.log(this.oneSortForm)
      Axios({
        url: 'https://localhost:44388/api/GoodType/InsertGoodTypeInfo',
        method: 'post',
        data: this.oneSortForm
      }).then(ex => {
        if (ex.data.data > 0) {
          this.$message({
            message: '恭喜你，分类添加成功！',
            type: 'success'
          }, { TimeRanges: 2000 });
          setInterval(() => {
            this.$router.go(0);
          }, 2000);
        } else {
          this.$message.error('很遗憾，分类添加失败！');
        }
      })
    },
    //编辑分类
    updatesort() {
      // console.log(this.tableDataone)
      Axios({
        url: 'https://localhost:44388/api/GoodType/UpdateGoodTypeInfo',
        method: 'put',
        data: this.tableDataone
      }).then(ex => {
        if (ex.data.data > 0) {
          this.$message({
            message: '恭喜你，分类编辑成功！',
            type: 'success'
          }, { TimeRanges: 2000 });
          setInterval(() => {
            this.$router.go(0);
          }, 2000);
        } else {
          this.$message.error('很遗憾，分类编辑失败！');
        }
      })
    },
    //分类删除
    delone(row) {
      this.$confirm('此操作将永久删除该分类, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        Axios({
          url: 'https://localhost:44388/api/GoodType/DeleteGoodType?typeid=' + row.typeId,
          method: 'delete'
        }).then(ex => {
          if (ex.data.data > 0) {
            this.$message({
              message: '恭喜你，分类删除成功！',
              type: 'success'
            }, { TimeRanges: 2000 });
            setInterval(() => {
              this.$router.go(0);
            }, 2000);
          } else if (ex.data.data < 0) {
            this.$message.error('很遗憾，该分类下存在商品信息，不可进行删除！');
          } else {
            this.$message.error('很遗憾，分类删除失败！');
          }
        })
      }).catch(() => {
        this.$message({
          type: 'info',
          message: '已取消删除'
        });
      });
    },
  }
}
</script>

<style scoped>
.sort {
  width: 100%;
  min-height: 100%;
  padding: 15px;
  box-sizing: border-box;
}

/* 一级分类 */
/* .sort-one {
  width: 100%;
  height: auto;
  padding: 10px;
  box-sizing: border-box;
  border-radius: 5px;
  border: 1px solid #eeeeee;
} */
/* 列表 */
.sort-one {
  width: 100%;
  height: auto;
  margin-bottom: 20px;
}


.sort-one-name {
  width: 100%;
  height: 50px;
  line-height: 50px;
  padding-left: 20px;
  font-size: 16px;
  font-weight: bold;
  letter-spacing: 2px;
}

.sort-one-add {
  display: flex;
  height: 50px;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.sort-one-add-submit {
  width: 100%;
}

.sort-one-head {
  width: 100%;
  margin-bottom: 15px;
}

/* 列表 */
.sort-one-list {
  width: 100%;
  height: auto;
  margin-bottom: 20px;
}


.sort-one-page-line {
  width: 100%;
  display: flex;
  justify-content: flex-end;
}
</style>