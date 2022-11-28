<template>
  <div class="goodsindex">
    <!-- 搜索条件 -->
    <el-row :gutter="20" class="goodsindex-queryInfo">
      <!-- 商品名称搜索 -->
      <el-col :xs="8" :sm="6" :md="6" :lg="4" :xl="4">
        <el-input class="goodsindex-queryInfo-li" v-model="queryInfo.name" clearable size="small" placeholder="请输入产品名称">
        </el-input>
      </el-col>
      <!-- 商品分类搜索 -->
      <el-col :xs="8" :sm="6" :md="6" :lg="4" :xl="4">
        <el-select class="goodsindex-queryInfo-li" v-model="queryInfo.type" size="small" clearable
          placeholder="请选择产品分类">
          <el-option v-for="item in options" :key="item.typeId" :label="item.typeName" :value="item.typeId">
          </el-option>
        </el-select>
      </el-col>
      <!-- 搜索 -->
      <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
        <el-button type="primary" class="goodsindex-queryInfo-li" size="small">搜索</el-button>
      </el-col>
      <!-- 查看上架商品信息 -->
      <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
        <el-button type="success" class="goodsindex-queryInfo-li" size="small" @click="showonindex">查看上架商品</el-button>
      </el-col>
      <!-- 返回商品列表 -->
      <el-col :xs="6" :sm="4" :md="3" :lg="2" :xl="2">
        <el-button type="success" class="goodsindex-queryInfo-li" size="small" @click="showgood">返回商品列表</el-button>
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
              <el-button size="mini" @click="shang(scope.row)">上架</el-button>
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
  </div>
</template>

<script>
import Axios from 'axios'
export default {
  data() {
    return {
      queryInfo: {
        name: '',
        type: '',
        page: 1,
        pageSize: 10
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
        url: 'https://localhost:44388/api/Good/GetShelGoodList?state=1',
        method: 'get'
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
    handleSizeChange() {

    },
    handleCurrentChange() {

    },
    //查看上架商品信息
    showonindex() {
      this.$router.push('/goods/OnIndex')
    },
    //返回商品列表
    showgood() {
      this.$router.push('/goods/index')
    },
    //上架商品
    shang(row) {
      this.$confirm('确认将该商品上架么, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        Axios({
          url: 'https://localhost:44388/api/Good/UpdateShelStateGoodInfo?goodid=' + row.goodsId + '&state= 3',
          method: 'put'
        }).then(ex => {
          if (ex.data.data > 0) {
            this.$message({
              message: '恭喜你，上架成功！',
              type: 'success'
            });
            this.fun();
          } else {
            this.$message.error('很遗憾，上架失败！');
          }
          this.fun()
        })
      }).catch(() => {
        this.$message({
          type: 'info',
          message: '已取消上架'
        });
      });
    },
  }
}
</script>

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