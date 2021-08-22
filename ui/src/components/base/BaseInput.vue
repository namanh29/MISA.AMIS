<template>
  <div>
    <div class="label">
      {{ label }} <span v-if="required"><span>*</span></span>
    </div>
    <div class="input-box">
      <input
        class="input-default input-label"
        :class="{ 'border-red': invalid, 'text-right': field == 'salary' }"
        :style="{ 'text-align': textAlign}"
        :type="type"
        :value="valueFormat"
        :name="field"
        @input="updateValue($event.target.value)"
        @blur="onBlur($event.target)"
        ref="BaseInput"
        v-tooltip.top="{ content: message }"
      />
      <div v-if="field == 'salary'" class="currency-type">(VNĐ)</div>
    </div>
  </div>
</template>

<script>
import Resource from '../../resource'
export default {
  name: "BaseInput",
  created() {
    if(this.field == 'salary'){
      this.textAlign = 'right'
    }
  },
  props: {
    label: {
      type: String
    },
    type: {
      type: String
    },
    value: {
      type: [String, Number]
    },
    required: {
      type: Boolean,
      default: false
    },
    field: {
      type: String
    },
    width: {
      type: String
    }
  },

  data() {
      return {
          invalid: false,
          message: '',
          textAlign: ''
      }
  },
  computed: {
    valueFormat() {
        switch (this.field) {
            case "salary":
                return this.formatCurrency(this.value?.toString());
            default:
                return this.value;
        }
    }
  },
  
  methods: {
    updateValue: function (value) {
      if(this.field == "salary"){
        value = this.formatCurrency(value);
      }
      this.$emit("input", value);
    },
    onBlur(e){
        if(this.required == true){
            if(e.value == '') {
                this.invalid=true;
                this.message = `${this.label} ${Resource.validateEmpty}`
            }
            else {
                this.invalid = false;
                this.message = ''
            }
        }
        if(e.type == 'email' && e.value != '' ){
            if( this.validateEmail(e.value) == false){
                this.invalid = true;
                this.message =  `${this.label} ${Resource.validateInvalid}`
            }
            else {
                this.invalid = false;
                this.message = ''
            }
        }
        if(e.name == 'phone' && e.value != '' ){
            if( this.validatePhone(e.value) == false){
                this.invalid = true;
                this.message = `${this.label} ${Resource.validateInvalid}`
            }
            else {
                this.invalid = false;
                this.message = ''
            }
        }
        if(e.name == 'salary'  ){
            if(  this.validateSalary(e.value) == false && e.value != ''){
                this.invalid = true;
                this.message = `${this.label} ${Resource.validateInvalid}`
            }
            else {
                this.invalid = false;
                this.message = ''
            }
        }
    },
    validateEmail(email){
        var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    },

    validatePhone(phone){
      var re = /^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$/;
      return re.test(phone);
    },

    validateSalary(salary){
      var re = /^[0-9]+$/;
      return re.test(salary);
    },
    formatCurrency(str) {
      return Intl.NumberFormat().format(Number(str?.replaceAll(".", "")?.replaceAll(",", "")) || 0).toString();
    }
  }
}
</script>

<style lang="css" scoped>
@import url("../../css/common/input.css");
@import url("../../css/common/dialog.css");
@import url("../../css/common/tooltip.css");


</style>