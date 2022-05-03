<template>
  <button
    @click="$emit('addedOperation', text)"
    class="bc__body__number-buttons__button"
  >
    {{ text }}
  </button>
</template>

<script>
export default {
  name: "OperationButton",
  props: {
    text: {
      type: String,
      required: true,
    },
  },
  data() {
    return {};
  },
};
</script>

<style lang="scss" scoped>
.bc__body__number-buttons__button {
  all: unset;
  cursor: pointer;
  height: 20%;
  width: 50%;
  font-size: 2em;
  color: white;
  background-color: #ff9500;
  border-radius: 16px;
  display: flex;
  margin: 12px;
  justify-content: center;
  align-items: center;
}
</style>
