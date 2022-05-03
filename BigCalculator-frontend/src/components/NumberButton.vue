<template>
  <button
    @click="$emit('addedCharacter', text)"
    class="bc__body__number-buttons__button"
  >
    {{ text }}
  </button>
</template>

<script>
export default {
  name: "NumberButton",
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
  width: 27%;
  margin: 12px;
  border-radius: 16px;
  background-color: #505050;
  font-size: 2em;
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
