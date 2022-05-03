<template>
  <div>
    Import Calculator
    <input type="file" @change="loadTextFromFile" />
    <br />
    {{ message }}
  </div>
</template>

<script>
export default {
  data() {
    return {
      message: "",
    };
  },
  methods: {
    loadTextFromFile(ev) {
      const file = ev.target.files[0];
      const reader = new FileReader();

      reader.onload = (e) => (this.message = e.target.result);
      reader.readAsText(file);
    },
  },
};
</script>

<style lang="scss" scoped></style>
