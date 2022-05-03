<template>
  <div class="bc_basic">
    <div class="es-page-header">
      <router-link class="nav" to="/"><button>home</button></router-link>
      <h3>Basic Calculator</h3>
    </div>
    <Calculator />
  </div>
</template>

<script>
import Calculator from "@/components/Calculator.vue";

export default {
  name: "BasicCalculator",
  components: {
    Calculator,
  },
};
</script>

<style lang="scss" scoped>
.bc_basic {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.es-page-header {
  display: flex;
  justify-content: center;
  align-items: center;
  .nav {
    margin-right: 40px;
    button {
      cursor: pointer;
      font-family: "HongKong";
      text-decoration: none;
      font-size: 16px;
      border: none;
      border-radius: 4px;
      color: #d4d4d2;
      transition: 0.2s all ease-in-out;
      padding: 14px 20px;
      background-color: #505050;
      &:hover {
        color: #ff9500;
      }
    }
  }
}
h3 {
  margin-bottom: 24px;
  color: #ff9500;
}
h6 {
  font-weight: 400;
  color: #ff9500;
  margin-top: 0px;
}
</style>
