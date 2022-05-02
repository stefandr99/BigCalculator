<template>
  <div class="bc_basic">
    <h3>Basic Calculator</h3>
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
