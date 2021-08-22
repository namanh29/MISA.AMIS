<template>
    <div class="popup">
        <div class="popup-modal"></div>
        <div class="popup-content">
            <div class="popup-body"> 
                    <div :class="icon"></div>
                    <div class="popup-info">
                        {{message}}
                    </div>
            </div>
            <div class="popup-line"></div>
            <div class="popup-footer">
                <div v-if="name==='closeForm'" class="close-form">
                    <div class="btn-left-group">
                        <BaseButton
                            btnType="second-button"
                            btnText="Hủy"
                            @click="btnCancel"
                        />
                    </div>
                    <div class="btn-right-group">
                        <BaseButton
                            btnType="second-button"
                            btnText="Không"
                            @click="btnNo"
                            
                        />
                        <BaseButton
                            class="p-l-8"
                            btnType="btn-default"
                            btnText="Có"
                            @click="btnYes"
                            
                        />
                    </div>
                </div>
                
                <div v-if="name==='validateEmpty'" class="validate-empty">
                    <BaseButton
                        btnType="btn-default"
                        btnText="Đóng"
                        @click="btnCancel"
                    />
                </div>
                <div v-if="name==='validateDuplicate'" class="validate-duplicate">
                    <BaseButton
                        btnType="btn-default"
                        btnText="Đóng"
                        @click="btnCancel"
                    />
                </div>
                <div v-if="name==='deleteWarning'" class="delete-warning">
                    <BaseButton
                        btnType="second-button"
                        btnText="Không"
                        @click="btnCancel"
                    />
                    <BaseButton
                        btnType="btn-default"
                        btnText="Có"
                        @click="btnConfirmDel"
                    />
                </div>
                
            </div>
        </div>
    </div>
</template>

<script>
import BaseButton from './BaseButton.vue';
export default {
  components: { BaseButton },
    props: {
        info: String,
        btnCancelText: String,
        btnConfirmText: String,
        btnNoText: String,
        btnYesText: String,
        type: String,
        name: String,
        message: String
    },
    data() {
        return {
            bgColor: '',
        }
    },
    created() {
        switch (this.type){
            case 'question': 
                this.icon = 'icon-question';
                break;
            case 'warning':
                this.icon = 'icon-warning';
                break;
            case 'error':
                this.icon = 'icon-error';
                break;
        }
    },
    methods: {
        btnCancel(){
            this.$emit("cancel");
        },
        btnNo(){
            this.$emit("close");
        },
        btnYes(){
            this.$emit("close-save");
        },
        btnConfirmDel(){
            this.$emit("confirm-delete")
        }
    }
}
</script>

<style lang="css">
    @import url('../../css/common/popup.css');
    @import url('https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css');
    .warning {
        color: #ffc021;
    }
    .delete {
        color: #ff623d
    }
</style>