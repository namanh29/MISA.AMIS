<template>
    <div class="navbar">
        <div class="logo-site">
            <div class="toggle-icon"></div>
            <div class="cukcuk-logo"></div>
        </div>
        <div class="navbar-content">
            <router-link to="/dashboard" class="nav-item">
                <div class="navbar-item-icon dashboard"></div>
                <div class="navbar-item-text">Tổng quan</div>
            </router-link>
            <router-link to="/employee" class="nav-item ">
                <div class="navbar-item-icon employee"></div>
                <div class="navbar-item-text">Danh mục nhân viên</div>
            </router-link>
            <router-link to="/BA" class="nav-item">
                <div class="navbar-item-icon bank"></div>
                <div class="navbar-item-text">Tiền gửi</div>
            </router-link>
            
            <router-link to="/PU" class="nav-item">
                <div class="navbar-item-icon bag"></div>
                <div class="navbar-item-text">Mua hàng</div>
            </router-link>
            <router-link to="/SA" class="nav-item">
                <div class="navbar-item-icon cart"></div>
                <div class="navbar-item-text">Bán hàng</div>
            </router-link>
            <router-link to="/IP" class="nav-item">
                <div class="navbar-item-icon invoice"></div>
                <div class="navbar-item-text">Quản lý hóa đơn</div>
            </router-link>
            <router-link to="/IN" class="nav-item">
                <div class="navbar-item-icon stock"></div>
                <div class="navbar-item-text">Kho</div>
            </router-link>
            <router-link to="/SU" class="nav-item">
                <div class="navbar-item-icon tools"></div>
                <div class="navbar-item-text">Công cụ dụng cụ</div>
            </router-link>
            <router-link to="/FA" class="nav-item">
                <div class="navbar-item-icon fixed-assets"></div>
                <div class="navbar-item-text">Tài sản cố định</div>
            </router-link>
            <router-link to="/TA" class="nav-item">
                <div class="navbar-item-icon tax"></div>
                <div class="navbar-item-text">Thuế</div>
            </router-link>
            <router-link to="/JC" class="nav-item">
                <div class="navbar-item-icon price"></div>
                <div class="navbar-item-text">Giá thành</div>
            </router-link>
            <router-link to="/GL" class="nav-item">
                <div class="navbar-item-icon general"></div>
                <div class="navbar-item-text">Tổng hợp</div>
            </router-link>
            <router-link to="/BUD" class="nav-item">
                <div class="navbar-item-icon budget"></div>
                <div class="navbar-item-text">Ngân sách</div>
            </router-link>
            <router-link to="/RP" class="nav-item">
                <div class="navbar-item-icon report"></div>
                <div class="navbar-item-text">Báo cáo</div>
            </router-link>
            
        </div>
    </div>
</template>

<style scoped>
    @import url('../../css/layout/navbar.css');
    
    .router-link-active {
        background-color: rgba(235,237,240,.2) !important;
        color: #ffffff !important;
        border-left-color: #2ca01c !important;
    }
    
</style>

<script>

    

export default {
    
}
</script>