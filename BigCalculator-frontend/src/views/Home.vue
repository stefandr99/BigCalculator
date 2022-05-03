<template>
  <div>
    <div class="bc-home-nav">
      <router-link class="nav" to="/basic">Basic Calculator</router-link>
      <router-link class="nav" to="/expression"
        >Expression Calculator</router-link
      >
      <router-link class="nav" to="/import">Import XML</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "Home",
  data() {
    return {};
  },
};
</script>

<style lang="scss" scoped>
.bc-home-nav {
  display: flex;
  flex-direction: column;
  align-items: center;
  .nav {
    transition: 0.2s all ease-in-out;
    padding: 14px 20px;
    background-color: #505050;
    border-radius: 14px;
    margin: 16px;
    text-decoration: none;
    color: #d4d4d2;
    box-shadow: rgba(0, 0, 0, 0.1) 0px 4px 6px -1px,
      rgba(0, 0, 0, 0.06) 0px 2px 4px -1px;
    &:hover {
      background-color: #505050;
      color: #ff9500;
      box-shadow: rgba(0, 0, 0, 0.1) 0px 10px 15px -3px,
        rgba(0, 0, 0, 0.05) 0px 4px 6px -2px;
    }
  }
}
</style>
