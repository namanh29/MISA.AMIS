<template>
    <div>
        <div class="label">
            {{label}} <span v-if="required"><span>*</span></span>
        </div>
        <div class="combobox" 
            @keydown="keyEvent($event)" 
            :class="{'cbx-active':cbxActive, 'border-red': invalid}" 
            :tabindex="index"
        >
            <input class="combobox-text" 
                type="text" 
                v-model="cbxInput" 
                @input="autocomplete" 
                @focus="cbxActive = true"
                @blur="onBlur($event.target)"
                ref="BaseInput"
                v-tooltip.top="{ content: message }"
                :disabled=isDisable
                >
            <button @click="toggleList"><div class="icon-button" :class="{'reverse':isShow}"></div></button>
            <div v-if="isShow" class="combobox-list" :class="[{'top-list': isTopList=='isTop'}, {'bottom-list': isTopList!='isTop'}]">
                <div class="combobox-item" 
                    v-for="(cbxItem, index) in cbxItems" 
                    :class="{'selected': cbxItem.isSelected, 'focus-item': index==currentFocus}"
                    :key="index"
                    @click="clickItem(cbxItem)"
                    >      
                    {{cbxItem.text}}
                </div>
            </div>
        </div>
    </div>
    
</template>

<script>

export default {
    props: {
        label: String,
        items: Array,
        required: {
            type: Boolean,
            default: false
        },
        index: String,
        isTopList: {
            type: String,
        },
        selectedItem: {
            type: [String, Number]
        },
        isDisable: {
            type: Boolean,
            default: false
        }
    },
    data() {
        return {
            comboboxItems: [], 
            isShow : false,
            cbxInput: '',
            cbxItems: [],
            currentFocus: 0,
            cbxActive: false,
            invalid: false,
            message:''
        }
    },
    watch: {
        selectedItem: {
            handler: function(val){
                this.cbxInput = '';
                this.comboboxItems.forEach(item=>{
                    item.isSelected = false;
                    if(item.value === val){
                        this.cbxInput = item.text;
                        item.isSelected = true;
                    }
                })
            },
            deep: true
        }
    },
    created() {
        var me = this;
        this.items.forEach(function(item,index){
            me.comboboxItems[index] = {
                value: item.value,
                text: item.text,
                isSelected: false,
            };
            if(me.comboboxItems[index].value === me.selectedItem){
                me.comboboxItems[index].isSelected = true;
                me.cbxInput = me.comboboxItems[index].text
            }
        })
        this.comboboxItems = [...this.comboboxItems]
            
    },
    
    methods: {
        /**
         * Hàm xử lý khi nhấn vào button toggle
         * CreatedBy: PNANH (21/8/2021)
         */
        toggleList(){
            this.isShow = !this.isShow;
            this.cbxActive = true
            //this.$refs.BaseInput.focus();
            
            this.cbxItems = this.comboboxItems
            this.currentFocus = 0;
        },

        /**
         * Hàm xử lý khi blur ra khỏi combobox
         * CreatedBy: PNANH (21/8/2021)
         */
        onBlur() {
            this.cbxActive = false;
            if(this.required == true){
                if(this.cbxInput == '') {
                    this.invalid=true;
                    this.message = `${this.label} không được để trống`
                }
                else {
                    this.invalid = false;
                    this.message = ''
                }
            }
        },
        clickItem(cbxItem){
            this.$refs.BaseInput.focus();
            this.currentFocus = 0;
            this.cbxInput = cbxItem.text; 
            this.comboboxItems.forEach(item=>{
                item.isSelected = false;
                if(item.value == cbxItem.value) {
                    item.isSelected = true;
                    
                    this.$emit("update-item", item) 
                } 
            })
            
            //this.$refs.BaseInput.blur();
            this.isShow = !this.isShow;
            console.log(this.comboboxItems)
            
        },

        autocomplete(){
            this.currentFocus = 0;
            var me = this;
            this.isShow = true;
            
            var val = this.cbxInput;
            if(val.length != 0){
                this.cbxItems = [];
                this.comboboxItems.forEach(function(item){
                    item.isSelected = false;
                    if (item.text.toUpperCase().includes(val.toUpperCase()) ) {
                        me.cbxItems.push(item)
                    }
                    
                })
            }
            else {
                this.cbxItems = [];
            }
            if(this.cbxItems.length === 0){
                this.isShow = false
            }
            
        },

        keyEvent(event){
            
            if(this.cbxItems.length != 0) {
                console.log(this.cbxItems);
                if (event.keyCode == 40) {
                    event.preventDefault();
                    this.currentFocus++;
                    if (this.currentFocus >= this.cbxItems.length) this.currentFocus = 0;
                    if (this.currentFocus < 0) this.currentFocus = (this.cbxItems.length - 1);
                }
                else if (event.keyCode == 38) {
                    event.preventDefault();
                    this.currentFocus--;
                    if (this.currentFocus >= this.cbxItems.length) this.currentFocus = 0;
                    if (this.currentFocus < 0) this.currentFocus = (this.cbxItems.length - 1);
                }
                else if (event.keyCode == 13) {
                    event.preventDefault();
                    if(this.currentFocus > -1){
                        
                        this.clickItem(this.cbxItems[this.currentFocus]);
                    }
                }
            }
            
        }
    }
}
</script>

<style lang="css" scoped>
    @import url('../../css/common/combobox.css');
    @import url("../../css/common/tooltip.css");
    button{
        position: relative;
    }
    
    
</style>