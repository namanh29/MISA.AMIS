<template>
  <div class="m-dialog dialog-detail" title="Thông tin nhân viên">
    <div class="dialog-modal"></div>
    <div class="dialog-content">
      <div class="dialog-header">
        <div class="header-title">
          <div class="title">Thông tin nhân viên</div> 
          <BaseCheckbox
            :items="entity"
          />  
        </div>
        <div class="header-button">
          <BaseButton btnType="btn-help" class="m-r-6"/>
          <BaseButton btnType="btn-x" @click="btnCancelClick" />
        </div>
        
      </div>
      <div class="dialog-main">

        <div class="dialog-infor-1">
          <div class="dialog-infor-left">
            
            <div class="label-infor">
              <BaseInput
                class="w-2-5 p-r-6"
                label="Mã"
                type="text"
                v-model="employee.EmployeeCode"
                :required="true"
                ref="input1"
              >
              </BaseInput>
              
              <BaseInput
                class="w-3-5"
                label="Tên"
                type="text"
                v-model="employee.EmployeeName"
                :required="true"
                ref="input2"
              >
              </BaseInput>
            </div>
            <div class="label-infor">
              
              <BaseCombobox
                class="w-full"
                label="Đơn vị"
                :items="departments"
                :selectedItem="employee.DepartmentId"
                @update-item="(item) => updateCombobox(item, 'department')"
                :required="true"
                ref="input3"
              /> 
            </div>
            <div class="label-infor">
              
              <BaseInput
                class="w-full"
                label="Chức danh"
                type="text"
                v-model="employee.EmployeePosition"
              >
              </BaseInput>
            </div>
           
            
          </div>
          <div class="dialog-infor-right">
            <div class="label-infor">
              <BaseInput
                class="w-2-5"
                label="Ngày sinh"
                type="date"
                v-model="employee.DateOfBirth"
              >
              </BaseInput>

              <BaseRadio
                class="w-3-5 p-l-16"
                label="Giới tính"
                :items="genders"
                :itemSelected="employee.Gender"
                @update-item="(item) => updateRadio(item, 'gender')"
              />
            </div>
            <div class="label-infor">
              <BaseInput
                class="w-3-5 p-r-6"
                label="Số CMTND/ Căn cước"
                type="text"
                v-model="employee.IdentityNumber"
              >
              </BaseInput>

              <BaseInput
                label="Ngày cấp"
                type="date"
                v-model="employee.IdentityDate"
              >
              </BaseInput>
            </div>
            <div class="label-infor">
              <BaseInput
                class="w-full"
                label="Nơi cấp"
                type="text"
                v-model="employee.IdentityPlace"
              >
              </BaseInput>
            </div>
          </div>
        </div>
        <div class="dialog-infor-2">

            <div class="label-infor">
              <BaseInput
                class="w-full"
                label="Địa chỉ"
                type="text"
                v-model="employee.Address"
              >
              </BaseInput>
            </div>
            <div class="label-infor">
              <BaseInput
                class="w-1-4 p-r-6"
                label="ĐT di động"
                type="text"
                v-model="employee.PhoneNumber"
                field="phone"
              >
              </BaseInput>
              <BaseInput
                class="w-1-4 p-r-6"
                label="ĐT cố định"
                type="text"
                v-model="employee.TelephoneNumber"
                field="phone"
              >
              </BaseInput>
              <BaseInput
                class="w-1-4 p-r-6"
                label="Email"
                type="email"
                v-model="employee.Email"
              >
              </BaseInput>

            </div>
            <div class="label-infor">
              <BaseInput
                class="w-1-4 p-r-6"
                label="Tài khoản ngân hàng"
                type="text"
                v-model="employee.BankAccountNumber"
              >
              </BaseInput>
              <BaseInput
                class="w-1-4 p-r-6"
                label="Tên ngân hàng"
                type="text"
                v-model="employee.BankName"
              >
              </BaseInput>
              <BaseInput
                class="w-1-4 p-r-6"
                label="Chi nhánh"
                type="text"
                v-model="employee.BankBranchName"
              >
              </BaseInput>
            </div>
          
        </div>
      </div>
      <div class="dialog-footer">
        <div>
          <BaseButton
            btnType="second-button"
            btnText="Hủy"
            @click="btnCancelClick"
          />
        </div>
        <div class="right-group-btn">
          <BaseButton
            class="p-r-10"
            btnType="second-button"
            btnText="Cất"
            @click="btnSaveClick"
          />
          <BaseButton
            btnType="btn-default"
            btnText="Cất và Thêm"
            @click="btnSaveAndAddClick"
          />
        </div>
        
      </div>
    </div>

    <BasePopup
      v-if="isShowPopup"
      @cancel="cancelPopup"
      @close="closeForm"
      @close-save="closeAndSave" 
      :type="typePopup"
      :name="namePopup"
      :message="contentPopup"
    >
    </BasePopup>
    
    
  </div>
</template>

<style lang="css" >
@import url("../../../css/common/dialog.css");
</style>

<script>
import EmployeeApi from "../../../api/employeeApi";

import Resource from '../../../resource'
import Const from '../../../const'
export default {
  name: "EmployeeDetail",

  created() {
    this.createData();
  },
  mounted() {
    // Sau khi mở form thì focus trường đầu tiên
    this.$refs["input1"].$refs["BaseInput"].focus();
    // Khi thêm mới nhân viên sẽ tự sinh mã
    if(this.formMode === 'add'){
      this.setDefaultForm()
    }
  },
  
  props: {
    employeeProp: Object,
    formmode: String,
    departmentsProp: {
      type: Array,
    },
  },

  data() {
    return {
      employee: { ...this.employeeProp, 
        DateOfBirth: this.formatDate(this.employeeProp.DateOfBirth),
        IdentityDate: this.formatDate(this.employeeProp.IdentityDate)
      },
      formMode: this.formmode,
      
    
      genders: [
          { value: Const.genders.male.value, text: Const.genders.male.text },
          { value: Const.genders.female.value, text: Const.genders.female.text },
          { value: Const.genders.other.value, text: Const.genders.other.text },
        ],
      departments: [],
      entity: [
        { value: Const.entity.customer.value, text: Const.entity.customer.text, isSelected: false },
        { value: Const.entity.supplier.value, text: Const.entity.supplier.text, isSelected: false },
      ],
      // Trạng thái form đã thay đổi chưa
      changedForm: false,

      isShowPopup: false,
      typePopup: '',
      contentPopup: '',
      namePopup: '',
    };
  },
  watch: {
    employee: {
      handler() {
        this.changedForm = true;
      },
      deep: true
    },
    
  },
  methods: {
    async createData() {
      let me = this;
      this.departmentsProp.forEach(function (item, index) {
        me.departments[index] = {
          value: item.DepartmentId,
          text: item.DepartmentName,
        };
      });
    },

    async setDefaultForm(){
      await this.getNewEmployeeCode();
      this.changedForm = false
    },
    /**
     * Hàm sinh mã nhân viên
     * CreatedBy: PNANH (20/8/2021)
     */
    async getNewEmployeeCode(){
      var newCode = await EmployeeApi.getNewEmployeeCode();
      this.employee = {...this.employee, EmployeeCode: newCode.data}
      //this.changedForm = false;
    },

    /**
     * Hàm xử lý khi nhấn Đóng form
     * CreatedBy: PNANH (20/8/2021)
     */
    btnCancelClick() {
      if(this.changedForm === true){
        this.contentPopup = Resource.closeForm
        this.typePopup = 'question'
        this.namePopup = 'closeForm'
        this.isShowPopup = true;
      }
      else {
        this.$emit("close-form")
      }
    },

    /**
     * Hàm xử lý khi nhấn Cất
     * CreatedBy: PNANH (21/8/2021)
     */
    async btnSaveClick(){
      var valid = this.validate();
      var success = false;
      if(valid == true){
        success = await this.onSave();
      }
      if(success == true){
        this.$emit("close-form");
        this.$emit("loadData");
      }
    },

    /**
     * Hàm xử lý khi nhân Cất và Thêm
     * CreatedBy: PNANH (21/8/2021)
     */
    async btnSaveAndAddClick(){
      var valid = this.validate();
      var success = false;
      if(valid == true){
        success = await this.onSave();
      }
      if(success == true){
        this.employee = {};
        
        this.getNewEmployeeCode();
        this.formMode = 'add'
      }
    },

    /**
     * Hàm validate dữ liệu
     * CreatedBy: PNANH (21/8/2021)
     */
    validate(){
      let isValid = true;
      const indexInvalid = [];
      Object.entries(this.$refs).forEach(function (item, index) {
        item[1].$refs.BaseInput.focus();
        item[1].$refs.BaseInput.blur();
        if (item[1].invalid == true) {
          isValid = false;
          indexInvalid.push(index);
        }
      });
      if (isValid == false) {
        // this.$store.commit("setToast", {
        //   type: "warning",
        //   message: "Dữ liệu không hợp lệ, vui lòng kiểm tra lại",
        // });
        Object.entries(this.$refs)[indexInvalid[0]][1].$refs.BaseInput.focus();
        console.log(Object.entries(this.$refs)[indexInvalid[0]][1].message);

        // Hiển thị popup cảnh báo dữ liệu không hợp lệ
        this.isShowPopup = true;
        this.contentPopup = Object.entries(this.$refs)[indexInvalid[0]][1].message
        this.typePopup = 'error'
        this.namePopup = 'validateEmpty'
      }
      return isValid;
    },

    // Hàm update combobox
    updateCombobox(item, type){
      if(type === 'department')
      this.employee = {...this.employee, DepartmentId: item.value, DepartmentName: item.text}
    },
    // Hàm update radio button
    updateRadio(item, type){
      if(type === 'gender')
      this.employee = {...this.employee, Gender: item}
    },

    /**
     * Hàm lưu nhân viên
     * CreatedBy: PNANH (21/8/2021)
     */
    async onSave() {
      var me = this;
      let success = false;
      
      // Thêm nhân viên
      if (this.formMode == "add") {
        try {
          const res = await EmployeeApi.add(this.employee);
          switch (res.status) {
            case 201:
              me.$store.commit("setToast", {
                type: "success",
                message: Resource.addSuccess,
              });
              success = true;
              break;

            case 200: 
              // Hiển thị popup cảnh báo dữ liệu không hợp lệ
              this.setPopup(res.data.UserMsg, 'warning', 'validateDuplicate')
              break;
            default:
              break;

            case 204: 
              me.$store.commit("setToast", {
                type: "error",
                message: Resource.errorException,
              });
              break;
          }              
        } catch (error) {
          console.log(error)
          me.$store.commit("setToast", {
            type: "error",
            message: Resource.errorException,
          });
          success = false;
        }
        
      } 
      // Sửa nhân viên
      else {
        try {
          const res = await EmployeeApi.update(
            this.employee.EmployeeId,
            this.employee
          );
          switch (res.status) {
            case 200:
              if(res.data.Success === true){
                me.$store.commit("setToast", {
                  type: "success",
                  message: Resource.updateSuccess,
                });
                success = true;
              }
              else {
                this.setPopup(res.data.UserMsg, 'warning', 'validateDuplicate')
              }
              break;

            case 204: 
              me.$store.commit("setToast", {
                type: "error",
                message: Resource.errorException,
              });
              break;
            default:
              break;
          }
          
        } catch (error) {
          me.$store.commit("setToast", {
            type: "error",
            message: Resource.errorException,
          });
          success = false;
        }
      }
      return success;
    },
    
    /**
     * Hàm tạo Popup
     * CreatedBy: PNANH (21/8/2021)
     */
    setPopup(content, type, name){
      this.isShowPopup = true;
      this.contentPopup = content
      this.typePopup = type
      this.namePopup = name
    },

    /**
     * Hàm format ngày tháng năm
     * CreatedBy: PNANH (21/8/2021)
     */
    formatDate(d) {
      if (d != null) {
        return d.substr(0, 10);
      }
    },

    /**
     * Hàm xử lý sự kiện của Popup
     * CreatedBy: PNANH (21/8/2021)
     */
    // Đóng popup
    cancelPopup() {
      this.isShowPopup = false;
    },
    // Đóng form
    closeForm() {
      this.$emit("close-form");
    },
    // Cất và đóng form
    closeAndSave(){
      this.btnSaveClick()
    }
  },
};
</script>