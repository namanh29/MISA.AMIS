<template>
  <div>
    <div class="label">{{label}}</div>
    <div class="checkboxItems">
      <label v-for="(item,index) in items" :key="index" class="container"
        >{{item.text}}
        <input v-model="valueRd" type="checkbox" :value="item.value"/>
        <span class="checkmark"></span>
      </label>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      valueRd: []
    }
  },
  props: {
    label: String,
    items: Array
  },
  watch: {
    valueRd(){
      console.log(this.valueRd);
      this.items.forEach(item=>{
        item.isSelected = false;
        if(item.value === this.valueRd){
          item.isSelected = true;
        }
      })
    }
  },
  created(){
    this.items.forEach(item=>{
      if(item.isSelected == true) {
        this.valueRd = item.value;
      }
    })
  }
}
</script>

<style scoped>
.checkboxItems {
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
  transition: all .2s ease;
  transform: rotate(-90deg);
}



/* When the radio button is checked, add a blue background */
.container input:checked ~ .checkmark {
  background-color: #fff;
  border: 1px solid#2ca01c;
  transform: rotate(0deg);
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
  top: 2px;
  left: 1px;
  
  background: url('../../assets/icon/Sprites.64af8f61.svg') no-repeat -1225px -363px;
	width: 14px;
	height: 11px;
}
</style>