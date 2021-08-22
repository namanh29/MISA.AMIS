<template>
  <div class="content">
    <div class="header-content">
      <div class="title">Nhân viên</div>
      <div class="content-feature">
        
        <BaseButton
          btnText="Thêm mới nhân viên"
          btnType="btn-default"
          @click="btnAddOnClick"
        />
      </div>
    </div>
    <div class="main-content">
      <div class="filter-bar">
        <div class="filter-left">
          <input
            class="input-default input-search"
            type="text"
            style="width: 240px"
            placeholder="Tìm kiếm theo Mã, Tên nhân viên"
            @keyup.enter="getEmployeeFilter()"
            v-model="employeeFilter"
          />
          <div class="icon-search"></div>
        </div>
        <div class="filter-right">
          <!-- <BaseButton
          btnType="btn-refresh second-button"
          @click="loadData"
          icon="icon-refresh"
        /> -->
          <button class="btn-refresh" @click="loadData">
            <div class="icon-refresh"></div>
          </button>
        </div>
      </div>
      <!-- Code moi -->
      <div class="grid-container">
        <div class="grid">
          <BaseTable
            :data="Employees"
            :fields="tableField"
            @on-click-edit="btnEditClick"
            @on-click-delete="btnDeleteClick"
            @on-click-replicate="btnReplicateClick"
          />
          
        </div>
        
      </div>
      <div class="paging-bar">
            <div class="paging-left">Tổng số:&nbsp;<b>{{totalRecords}}</b>&nbsp;bản ghi</div>
            <div class="paging-right">
              <BaseCombobox
                class="paging-cbx"
                :items="paginations"
                :isDisable="true"
                isTopList="isTop"
                :selectedItem="perPage"
                @update-item="updateCombobox"
              />
              <Pagination
                class="paging"
                :total-pages="totalPages"
                :current-page="currentPage"
                @pagechanged="onPageChange"
              />
            </div>
          </div>
    </div>

    <EmployeeDetail
      v-if="isShowDetail"
      @close-form="closeForm"
      @loadData="loadData()"
      :employeeProp="employeeCurrent"
      :formmode="formMode"
      :departmentsProp="departments"
    />
    <BasePopup
      v-if="isShowPopupDel"
      @cancel="cancelPopup"
      @confirm-delete="deleteEmployee"
      type="warning"
      :message="contentPopup"
      name="deleteWarning"
    > 
    </BasePopup>

    <BaseLoader v-if="isShowLoader" />
  </div>
</template>

<script>
import EmployeeDetail from "./EmployeeDetail.vue";
import EmployeeApi from "../../../api/employeeApi";
import DepartmentApi from "../../../api/departmentApi";
import BaseTable from "../../../components/base/BaseTable.vue";
import Const from "../../../const"

export default {
  name: "ThePage",
  components: {
    EmployeeDetail,
    BaseTable,
  },

  data() {
    return {
      Employees: [],
      isShowDetail: false,
      employeeCurrent: {},
      formMode: "",
      
      departments: [],

      tableField: [
        { fieldName: "EmployeeCode", text: "Mã nhân viên" },
        { fieldName: "EmployeeName", text: "Tên nhân viên" },
        { fieldName: "GenderName", text: "Giới tính" },
        {
          fieldName: "DateOfBirth",
          text: "Ngày sinh",
          textAlign: "text-align-center",
          format: "date",
        },
        { fieldName: "IdentityNumber", text: "Số CMND" },
        { fieldName: "EmployeePosition", text: "Chức danh" },
        { fieldName: "DepartmentName", text: "Tên đơn vị" },
        { fieldName: "BankAccountNumber", text: "Số tài khoản" },
        { fieldName: "BankName", text: "Tên ngân hàng" },
        { fieldName: "BankBranchName", text: "Chi nhánh tk ngân hàng" },
      ],

      isShowPopupDel: false,
      contentPopup: '',
      isShowLoader: false,

      // pagination
      currentPage: 1,
      totalPages: 0,
      totalRecords: 0,
      perPage: 10,
      employeeFilter: "",
      paginations: Const.paginations,
        
    };
  },
  created() {
    this.loadData();
    this.iShowLoader = false;
  },

  watch: {
    // Gọi hàm filter khi thay đổi số bản ghi mỗi trang 
    perPage() {
      this.getEmployeeFilter();
    },
  
  },
  methods: {
    /**
     * Hàm lấy dữ liệu từ api
     * CreatedBy: PNANH (21/8/2021)
     */
    async loadData() {
      this.Employees = [];
      let me = this;
      me.isShowLoader = true;

      const promise = await Promise.all([
        EmployeeApi.getEmployeeFilter("", this.perPage, 1),
        //EmployeeApi.getAll(),
        DepartmentApi.getAll(),
      ]);
      me.totalPages = promise[0].data.TotalPage;
      me.totalRecords = promise[0].data.TotalRecord;
      me.currentPage = 1;
      setTimeout(function () {
        me.isShowLoader = false;
        me.Employees = promise[0].data.Data;
      }, 300);
      this.departments = promise[1].data;
    },

    /**
     * Hàm xử lý khi nhấn Thêm nhân viên
     * CreatedBy: PNANH (21/8/2021)
     */
    async btnAddOnClick() {
      this.formMode = "add";
      this.isShowDetail = true;
    },

    /**
     * Hàm đóng form chi tiết 
     * CreatedBy: PNANH (21/8/2021)
     */
    closeForm() {
      this.isShowDetail = false;
      this.employeeCurrent = {};
    },
    
    /**
     * Hàm xử lý khi nhấn Sửa 
     * CreatedBy: PNANH (21/8/2021)
     */
    btnEditClick(item) {
      this.formMode = "edit";
      this.isShowDetail = true;
      console.log(item.EmployeeId);
      this.employeeCurrent = item;
    },

    /**
     * Hàm xử lý khi nhấn Nhân bản
     * CreatedBy: PNANH (21/8/2021)
     */
    async btnReplicateClick(item){
      this.formMode = "add";
      this.employeeCurrent = item;
      this.isShowDetail = true;
    },
    
    /**
     * Hàm xử lý khi nhấn Xóa 
     * CreatedBy: PNANH (21/8/2021)
     */
    btnDeleteClick(item) {
      this.employeeCurrent = item;
      this.contentPopup = `Bạn có chắc chắn muốn xóa Nhân viên <${item.EmployeeCode}> không`
      this.isShowPopupDel = true;
        
    },

    /**
     * Hàm đóng popup
     * CreatedBy: PNANH (21/8/2021)
     */
    cancelPopup() {
      this.isShowPopupDel = false;
    },

    /**
     * Hàm Xóa nhân viên 
     * CreatedBy: PNANH (21/8/2021)
     */
    async deleteEmployee() {
      await EmployeeApi.delete(this.employeeCurrent.EmployeeId);
      this.isShowPopupDel = false;
      this.loadData();
      this.employeeCurrent = {}
    },
    updateCombobox(item){
      this.perPage = item.value
    },

    /**
     * Hàm lọc dữ liệu(filter) 
     * CreatedBy: PNANH (21/8/2021)
     */
    async getEmployeeFilter() {
      this.currentPage = 1;
      this.Employees = [];
      let me = this;
      me.isShowLoader = true;

      const res = await EmployeeApi.getEmployeeFilter(
        me.employeeFilter,
        me.perPage,
        me.currentPage
      );
      me.totalPages = res.data.TotalPage;
      me.totalRecords = res.data.TotalRecord;
      setTimeout(function () {
        (me.isShowLoader = false), (me.Employees = res.data.Data);
      }, 300);
    },

    /**
     * Hàm phân trang 
     * CreatedBy: PNANH (21/8/2021)
     */
    async onPageChange(page) {
      console.log(page);
      this.currentPage = page;
      this.Employees = [];
      let me = this;
      me.isShowLoader = true;

      const res = await EmployeeApi.getEmployeeFilter(
        this.employeeFilter,
        this.perPage,
        page
      );
      setTimeout(function () {
        (me.isShowLoader = false), (me.Employees = res.data.Data);
      }, 300);
    },
  },
};
</script>

<style scoped>
@import url("../../../css/layout/content.css");
@import url("../../../css/common/tooltip.css");

.selectedrow {
  background-color: #019160 !important;
}
.opened {
  background-color: #019160 !important;
}

</style>