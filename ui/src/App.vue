<template>
  <div id="app">
    <div class="layout">
      <TheMenu/>
      <div class="content-area">
        <TheHeader/>
        <ThePage/>
      </div>
    </div>

    <ToastMessage :newToast="$store.state.toastMessage.toast"/>
  </div>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue'
import TheMenu from './components/layout/TheMenu.vue'
import ThePage from './components/layout/ThePage.vue'
import ToastMessage from './components/base/ToastMessage/index.vue'

export default {
  name: 'App',
  components: {
    TheHeader, TheMenu,
    ThePage, ToastMessage
  }
}
</script>

<style>
  @import url('css/layout/main.css');
  .layout {
    display: flex;
    height: 100vh;
    max-width: 100%;
    
    
  }
  .content-area {
    max-width: calc(100% - 210px);
    flex:1
  }
 
</style>
