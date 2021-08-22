<template>
  <div>
    <div class="label">Giới tính</div>
    <div class="radioItems">
      <label v-for="(item,index) in items" :key="index" class="container"
        >{{item.text}}
        <input v-model="valueRd" type="radio" checked="checked" name="radio" :value="item.value"/>
        <span class="checkmark"></span>
      </label>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      valueRd: this.itemSelected
    }
  },
  props: {
    items: Array,
    itemSelected: {
      type: Number,
      default: 1,
    }
  },
  watch: {
    valueRd(value){
      this.$emit("update-item", value);
    },
    itemSelected(value){
      this.valueRd = value
    }
  },
}
</script>

<style scoped>
.radioItems {
  display: flex;
  height: 32px;
  align-items: center;
}
/* The container */
.container {
  display: block;
  position: relative;
  padding-left: 28px;
  margin-right: 20px;
  cursor: pointer;
  
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

/* Hide the browser's default radio button */
.container input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
}

/* Create a custom radio button */
.checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 18px;
  width: 18px;
  background-color: #fff;
  border: 1px solid #bbb;
  border-radius: 50%;
  
}



/* When the radio button is checked, add a blue background */
.container input:checked ~ .checkmark {
  background-color: #fff;
  border: 1px solid#2ca01c;
}

/* Create the indicator (the dot/circle - hidden when not checked) */
.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

/* Show the indicator (dot/circle) when checked */
.container input:checked ~ .checkmark:after {
  display: block;
}

/* Style the indicator (dot/circle) */
.container .checkmark:after {
  top: 3px;
  left: 3px;
  width: 10px;
  height: 10px;
  border-radius: 50%;
  background: #2ca01c;
}
</style>