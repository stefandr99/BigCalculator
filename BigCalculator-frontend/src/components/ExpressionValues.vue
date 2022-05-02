<template>
  <div class="bc-expression-pairs">
    <div v-for="(item, key, index) in keys" :key="index">
      <div class="bc-expression-pair">
        <div class="bc-expression-variable">{{ key }}</div>
        =
        <input class="bc-expression-variable-input" v-model="keys[key]" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ExpressionValues",
  props: {
    keys: {
      type: Object,
    },
  },
};
</script>

<style lang="scss" scoped>
.bc-expression-pair {
  display: flex;
  align-items: center;
  justify-content: center;
}
.bc-expression-variable {
  padding: 18px;
  margin: 8px;
  background: #505050;
  color: #d4d4d2;
  border-radius: 8px;
}
.bc-expression-variable-input {
  font-size: 22px;
  background: #505050;
  border: 1px solid #505050;
  border-radius: 8px;
  padding: 23px;
  margin: 8px;
  color: #d4d4d2;
  &:focus {
    outline: none;
  }
}
</style>
