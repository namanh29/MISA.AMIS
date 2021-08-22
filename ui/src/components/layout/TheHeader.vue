<template>
    <div class="header">   
        <div class="header-left">
            <div class="icon-3-stripes"></div>
            <BaseDropdown
            :dropdownItems="dropdownItems.titles"
            class="header-title"
        />
        </div>
        
        <div class="header-user">
            <div class="noti-icon"></div>
            <div class="avatar-img"></div>
            <div class="user-name">Phạm Nam Anh</div>
            <div class="option"></div>
        </div>
    </div>
</template>
<style lang="css" scoped>
    @import url('../../css/layout/header.css');
    .header .header-title input{
        font-size: 15px;
        font-weight: bold;
        border: none;
    }
</style>
<script>
    export default {
        name:"TheHeader",
        data() {
            return {
                dropdownItems: {
                    titles: [
                        { value: 0, text: "Công ty TNHH sản xuất - thương mại - dịch vụ Qui Phúc", isSelected: true },
                        { value: 1, text: "Nhà hàng Biển Tây", isSelected: false },
                        { value: 2, text: "Nhà hàng Biển Nam", isSelected: false },
                    ],
                }
            }   
        },
    }
</script>