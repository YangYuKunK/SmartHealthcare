<template>
  <div class="goodsindex">
    <!-- 搜索条件 -->
    <el-row :gutter="20" class="goodsindex-queryInfo">
      <!-- 商品名称搜索 -->
      <el-col :xs="8" :sm="6" :md="6" :lg="4" :xl="4">
        <el-input class="goodsindex-queryInfo-li" v-model="GoodsType.name" clearable size="small" placeholder="请输入产品名称">
        </el-input>
      </el-col>
      <!-- 商品分类搜索 -->
      <el-col :xs="8" :sm="6" :md="6" :lg="4" :xl="4">
        <el-select class="goodsindex-queryInfo-li" v-model="GoodsType.type" size="small" clearable
          placeholder="请选择产品分类">
          <el-option v-for="item in options" :key="item.typeId" :label="item.typeName" :value="item.typeId">
          </el-option>
        </el-select>
      </el-col>
      <!-- 搜索 -->
      <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
        <el-button type="primary" class="goodsindex-queryInfo-li" @click="getgood(GoodsType)" size="small">搜索
        </el-button>
      </el-col>
      <!-- 新增商品 -->
      <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
        <el-button type="success" class="goodsindex-queryInfo-li" size="small" @click="AddGood">新增商品
        </el-button>
      </el-col>
      <!-- 查看回收站 -->
      <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
        <el-button type="success" class="goodsindex-queryInfo-li" size="small" @click="showgc">查看回收站</el-button>
      </el-col>
      <!-- 查看上架商品 -->
      <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
        <el-button type="success" class="goodsindex-queryInfo-li" size="small" @click="showon">查看上架商品</el-button>
      </el-col>
      <!-- 查看下架商品 -->
      <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
        <el-button type="success" class="goodsindex-queryInfo-li" size="small" @click="showoff">查看下架商品</el-button>
      </el-col>
    </el-row>
    <!-- 检索结果 -->
    <el-row :gutter="20" class="goodsindex-list">
      <el-col :span="24">
        <el-table :data="tableData" border size='small' style="width: 100%">
          <el-table-column prop="goodsId" type="index" label="商品序号">
          </el-table-column>
          <el-table-column label="商品图片" width="150">
            <template slot-scope="scope">
              <img :src="scope.row.goodsImg" height="100">
            </template>
          </el-table-column>
          <el-table-column prop="goodsName" label="商品名称">
          </el-table-column>
          <el-table-column prop="goodsDescription" label="商品简介">
          </el-table-column>
          <el-table-column prop="goodsPrice" label="商品单价">
          </el-table-column>
          <el-table-column prop="goodsSpecification" label="商品规格">
          </el-table-column>
          <el-table-column prop="goodsNumber" label="存货数量">
          </el-table-column>
          <el-table-column prop="typeName" label="商品分类">
          </el-table-column>
          <el-table-column prop="goodsServe" label="商品售后服务">
          </el-table-column>
          <el-table-column label="操作">
            <template slot-scope="scope">
              <el-button size="mini" @click="UptGoodInfo(scope.row)">编辑</el-button>
              <el-button size="mini" type="danger" @click="gc(scope.row)">加入回收站</el-button>
            </template>
          </el-table-column>
        </el-table>
      </el-col>
    </el-row>
    <!-- 分页 -->
    <el-row :gutter="20" class="goodsindex-list">
      <el-col :span="24" class="goodsindex-page-box">
        <el-pagination :hide-on-single-page="true" @size-change="handleSizeChange" @current-change="handleCurrentChange"
          :current-page="queryInfo.page" :page-sizes="[10, 20, 50, 100]" :page-size="queryInfo.pageSize"
          layout="total, sizes, prev, pager, next, jumper" :total="400">
        </el-pagination>
      </el-col>
    </el-row>
    <!-- 编辑商品弹出层 -->
    <el-dialog title="编辑商品" :visible.sync="UptGoodShwo">
      <el-form :model="goodFrom" :rules="ruleGood" ref="goodFrom" label-width="120px" class="demo-ruleForm">
        <el-form-item label="当前图片" :label-width="formLabelWidth" prop="name">
          <el-upload class="upload-demo" :action="fangwen" :file-list="imgadd" :on-success="handleChange"
            list-type="picture">
            <el-button size="small" type="primary">点击上传</el-button>
            <div slot="tip" class="el-upload__tip">(如果不需要修改图片可以不修改)</div>
            <div slot="tip" class="el-upload__tip">只能上传jpg/png文件,且不超过500kb</div>
          </el-upload>
        </el-form-item>
        <el-form-item label="商品名称" prop="goodsName">
          <el-input v-model="goodFrom.goodsName" placeholder="请输入商品名称"></el-input>
        </el-form-item>
        <el-form-item label="商品单价" prop="goodsPrice">
          <el-input-number v-model="goodFrom.goodsPrice" :precision="2" :step="0.1" :max="100000" :min="0.1"
            placeholder="请输入商品单价"></el-input-number>
        </el-form-item>
        <el-form-item label="商品数量" prop="goodsNumber">
          <el-input v-model="goodFrom.goodsNumber" placeholder="请输入商品数量"></el-input>
        </el-form-item>
        <el-form-item label="商品简介" prop="goodsDescription">
          <el-input v-model="goodFrom.goodsDescription" placeholder="请输入商品简介"></el-input>
        </el-form-item>
        <el-form-item label="商品规格" prop="goodsSpecification">
          <el-input v-model="goodFrom.goodsSpecification" placeholder="请输入商品规格"></el-input>
        </el-form-item>
        <el-form-item label="商品售后服务" prop="goodsServe">
          <el-input v-model="goodFrom.goodsServe" placeholder="请输入商品售后服务"></el-input>
        </el-form-item>
        <el-form-item label="商品类型" prop="typeId">
          <el-select class="goodsindex-queryInfo-li" v-model="goodFrom.typeId" size="small" clearable
            placeholder="请输入商品类型">
            <el-option v-for="item in options" :key="item.typeId" :label="item.typeName" :value="item.typeId">
            </el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="UptadaGoodInfo('goodFrom')">提 交</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import Axios from 'axios'

export default {
  data() {
    return {
      //上传文件网址
      fangwen: "https://localhost:44388/api/good/UpLoad",
      imgadd: [],
      goodFrom: {
        pick: 8
      },
      //编辑弹框
      UptGoodShwo: false,
      //分类
      GoodsType: {
        name: '',
        type:''
      },
      //分页
      queryInfo: {
        page: 1,
        pageSize: 10
      },
      formLabelWidth: '120px',
      ruleGood: {

      },
      options: [],
      tableData: []
    }
  },
  created() {
    this.fun()
  },
  methods: {
    fun() {
      Axios({
        url: 'https://localhost:44388/api/Good/GetGoodList',
        method: 'get',
        data: this.queryInfo
      }).then(ex => {
        this.tableData = ex.data.data
        //获取商品分类信息
        Axios({
          url: 'https://localhost:44388/api/GoodType/GetGoodTypeList',
          method: 'get'
        }).then(ex => {
          this.options = ex.data.data
        })
      })
    },
    //编辑弹框
    UptGoodInfo(row) {
      console.log(row)
      this.goodFrom = row;
      this.UptGoodShwo = true
    },
    handleSizeChange() {

    },
    handleCurrentChange() {

    },
    handleChange(file) {
      console.log(file)
      this.goodFrom.GoodsImg = file.newFileName;
    },
    //查看回收站
    showgc() {
      this.$router.push('/goods/gc')
    },
    //查看上架商品
    showon() {
      this.$router.push('/goods/onindex')
    },
    //查看下架商品
    showoff() {
      this.$router.push('/goods/Offindex')
    },
    //新增商品信息
    AddGood() {
      this.$router.push('/goods/fromgood')
    },
    //加入回收站
    gc(row) {
      this.$confirm('确认将该商品加入回收站么, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        Axios({
          url: 'https://localhost:44388/api/Good/UpdateDeleteStateGood?goodid=' + row.goodsId + '&state= 0',
          method: 'put'
        }).then(ex => {
          if (ex.data.data > 0) {
            this.$message({
              message: '恭喜你，加入回收站成功！',
              type: 'success'
            })
            setInterval(() => {
              this.$router.go(0);
            }, 2000);
          } else {
            this.$message.error('很遗憾，加入回收站失败！');
          }
          this.fun()
        })
      }).catch(() => {
        this.$message({
          type: 'info',
          message: '已取消加入回收站'
        });
      });
    },
    //搜索
    getgood(queryInfo) {
      console.log(queryInfo)
      Axios({
        url: 'https://localhost:44388/api/good/SelectGoodList?goodname=' + GoodsType.name + '&typeid=' + GoodsType.type + '&delstate= 0',
        method: 'get'
      }).then(ex => {
        console.log(ex.data.data)
        this.tableData = ex.data.data
        // if (this.queryInfo.type == 0) { 
        //   this.queryInfo.type = null
        // }
        // console.log(this.queryInfo.type)
      })
    },
    //编辑商品信息
    UptadaGoodInfo() {
      console.log(this.goodFrom)
      Axios({
        url: 'https://localhost:44388/api/good/UpdateGoodInfo',
        data: this.goodFrom,
        method: 'put'
      }).then(ex => {
        if (ex.data.data > 0) {
          this.$message({
            message: '恭喜你，编辑商品成功！',
            type: 'success'
          }, { TimeRanges: 2000 });
          setInterval(() => {
            this.$router.go(0);
          }, 2000);
        }
        else {
          this.$message.error('很遗憾，编辑商品失败！');
        }
      })
    },
  }
}
</script>

<!--样式-->
<style scoped>
.goodsindex {
  width: 100%;
  min-height: 100%;
  padding: 15px;
  box-sizing: border-box;
}

/* 搜索 */
.goodsindex-queryInfo {
  margin-bottom: 10px;
}

.goodsindex-queryInfo-li {
  width: 100%;
  height: auto;
}

/* 列表 */
.goodsindex-list {
  width: 100%;
  height: auto;
  margin-bottom: 20px;
}

/* 分页 */
.goodsindex-page-box {
  width: 100%;
  height: auto;
  display: flex;
  justify-content: flex-end;
}
</style>