<template>
    <div class="page-num">
        <div class="page-pre">
            <button @click="onClickPrePage" :disabled="isInFirstPage">
              Trước
            </button>
        </div>
        <div class="page-first" v-if="currentPage > 2">
            <button @click="onClickFirstPage" :disabled="isInFirstPage">
              1
            </button>
            <span>...</span>
        </div>
        
        <div class="page-num-item"
            v-for="(page,index) in pages" :key="index">
            <button @click="onClickPage(page.name)" :disabled="page.isDisabled" :class="{active: isPageActive(page.name)}">
              {{page.name}}
            </button>
        </div>
        <div class="page-last" v-if="currentPage < totalPages - 2">
            <span>...</span>
            <button @click="onClickLastPage" :disabled="isInLastPage">
                {{totalPages}}
            </button>
        </div>
        <div class="page-next">
            <button @click="onClickNextPage" :disabled="isInLastPage">
                Sau
            </button>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        maxVisibleButtons: {
            type: Number,
            required: false,
            default: 3
        },
        totalPages: {
            type: Number,
            required: true
        },
        
        currentPage: {
            type: Number,
            required: true
        }
    },
    computed: {
        startPage(){
            // Khi ở page đầu
            if(this.currentPage === 1) {
                return 1;
            }
            // Khi ở page cuối
            if(this.currentPage === this.totalPages){
                return this.totalPages - this.maxVisibleButtons + 1;
            }
            // Khi ở các page giữa 
            return this.currentPage - 1;
        },
        endPage(){
            return Math.min(this.startPage + this.maxVisibleButtons - 1, this.totalPages);
        },
        pages() {
            const range = [];
            for(let i = this.startPage; i <= this.endPage; i++){
                range.push({name: i, isDisabled: i === this.currentPage});
            }
            return range;
        },
        isInFirstPage(){
            return this.currentPage === 1;
        },
        isInLastPage(){
            return this.currentPage === this.totalPages;
        }
    },
    methods: {
        onClickFirstPage(){
            this.$emit('pagechanged', 1);
        },
        onClickPrePage(){
            this.$emit('pagechanged', this.currentPage - 1);
        },
        onClickPage(page){
            this.$emit('pagechanged', page)
        },
        onClickNextPage(){
            this.$emit('pagechanged', this.currentPage + 1);
        },
        onClickLastPage(){
            this.$emit('pagechanged', this.totalPages);
        },
        isPageActive(page){
            return this.currentPage === page;
        }
    },
}
</script>

<style lang="css">
    .page-num {
        display: flex;
    }
    .page-pre {
        margin-right: 13px;
    }
    .page-next {
        margin-left: 13px;
    }
    .page-num button {
        border: none;
        outline: none;
        height: 20px;
        background-color: #fff;
        text-align: center;
        font-size: 13px;
        color: #111;
    }
    .page-num-item button, .page-first button, .page-last button{
        display: inline-block;
        padding: 0 6.5px;
    }
    .page-num button:hover {
        background-color: #e5e5e5;
        cursor: pointer;
    }
    .page-num-item .active  {
        
        font-weight: 700;
        border: 1px solid #e0e0e0;
    }
</style>