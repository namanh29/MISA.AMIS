<template>
    <div class="loader-modal">
        <div class="loader-content">

        </div>
    </div>
</template>

<style scoped>
.loader-modal {
    
    position: absolute; /* Stay in place */
    z-index: 999; /* Sit on top */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.3); /* Black w/ opacity */
}
    .loader-content {
  /* border: 10px solid #f3f3f3; 
  border-top: 10px solid #3498db; 
  border-radius: 50%; */
  background: url('../../assets/img/loading.svg') no-repeat;
  background-size: contain;
  width: 50px;
  height: 50px;
  animation: spin 2s linear infinite;
  top: 50%;
  margin: auto;
  margin-top: calc(50vh - 25px); 
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

</style>