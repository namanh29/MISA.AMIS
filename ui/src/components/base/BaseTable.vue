<template>
  
    <table border="0" cellspacing="0">
      <colgroup>
        <col style="width: 120px" />
        <col style="width: 170px" />
        <col style="width: 130px" />
        <col style="width: 120px" />
        <col style="width: 120px" />
        <col style="width: 260px" />
        <col style="width: 120px" />
        <col style="width: 120px" />
        <col style="width: 130px" />
        <col style="width: 130px" />
      </colgroup>
      <thead>
        <tr>
          <th class="out-left-white-16"></th>
          <th class="th-sticky"><input type="checkbox"></th>
          <th
            v-for="(field, index) in fields"
            :key="index"
            :fieldName="field.fieldName"
            :class="field.textAlign"
          >
            {{ field.text }}
          </th>
          <th class="feature">Chức năng</th>
          <th class="out-right-white-30"></th>
          <th class="out-right-grey-30"></th>
        </tr>
      </thead>
      <tbody>
        <tr
            v-for="(item,index) in data"
            v-bind:key="index"
            :class="{ 'isSelected': featureIndexs.includes(index) }"
        >
            <td class="out-left-white-16"></td>
            <td class="td-sticky"><input type="checkbox"></td>
            <td 
                v-for="(field,key) in fields"
                :key="key"
                :class="field.textAlign"
            >
                {{ format(item[field.fieldName], field.format) }}
            </td>
            <td class="function sticky" >
              <button class="func-btn-text" @click="onClickEdit(item)"><div class="border">Sửa</div></button>
              <button class="func-btn-icon" @click="onClickDropdown(index)">
                <div class="border"><div class="icon"></div></div>
                
              </button>
              <div 
                v-if="featureIndexs.includes(index)"
                class="feature"
              >
                <div @click="onClickReplicate(item)">Nhân bản</div>
                <div @click="onClickDelete(item)">Xóa</div>
                <div @click="onClickStop">Ngưng sử dụng</div>
              </div>
            </td>
            <td class="out-right-white-30"></td>
            <td class="out-right-grey-30"></td>
        </tr>
      </tbody>
    </table>
  
</template>

<script>
export default {
  props: {
    data: {
      type: Array,
    },
    fields: {
      type: Array,
    },
    opened: {
        type: Array
    }
  },
  data() {
      return {
          selectedItems: this.opened,
          featureIndexs: []
      }
  },
    methods: {
        format(value, format){
            if(format == null) {
                return value;
            }
            /** -------------------------------------------
             * Format dữ liệu ngày tháng sang ngày/tháng/năm
             * CreateBy: PNANH (04/07/2021)
             */
            if(format == "date"){
                if(!value) return ""
                var date = new Date(value);
                if (Number.isNaN(date.getTime())) {
                    return "";
                } else {
                    var day = date.getDate(),
                    month = date.getMonth() + 1,
                    year = date.getFullYear();
                    day = day < 10 ? "0" + day : day;
                    month = month < 10 ? "0" + month : month;
                    return `${day}/${month}/${year}`;
                }
            }
            /**
             * Hàm định dạng hiển thị tiền tệ
             * CreatedBy: PNANH (04/07/2021)
             */
            if(format == "money"){
                if (value) {
                    return value.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
                }
                return "";
            }
        },
        
        onClickEdit(item){
          this.$emit("on-click-edit",item)
        },
        onClickDropdown(index){
          let i = this.featureIndexs.indexOf(index);
            if (i > -1) {
                this.featureIndexs.splice(i, 1);
            } else {
                this.featureIndexs = [];
                this.featureIndexs.push(index);
            }
        },
        onClickDelete(item){
          this.featureIndexs = []
          this.$emit("on-click-delete", item)
        },
        onClickReplicate(item){
          this.featureIndexs = []
          this.$emit("on-click-replicate", item)
        },
        onClickStop(){
          this.featureIndexs = []
        }
    },
};
</script>

<style scoped>
    .isSelected {
        z-index: 3;
    }
</style>