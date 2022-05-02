<template>
  <div class="bc-expression__field">
    <input
      v-model="data.expression"
      class="bc-expression__field__input"
      type="text"
    />
  </div>
</template>

<script>
export default {
  name: "Expression",
  props: {
    data: {
      type: Object,
    },
  },
};
</script>

<style lang="scss" scoped>
.bc-expression__field {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  min-width: 700px;
  &__input {
    letter-spacing: 2px;
    width: 100%;
    height: 40px;
    border: 1px solid #505050;
    background: #505050;
    border-radius: 4px;
    padding: 20px 20px;
    font-size: 20px;
    color: #d4d4d2;
    box-shadow: rgba(0, 0, 0, 0.1) 0px 4px 6px -1px,
      rgba(0, 0, 0, 0.06) 0px 2px 4px -1px;
    &:focus {
      outline: none;
    }
  }
}
</style>
