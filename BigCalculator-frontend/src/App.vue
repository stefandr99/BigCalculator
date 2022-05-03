<template>
  <div class="bc">
    <router-view />
  </div>
</template>

<script>
export default {
  name: "App",
};
</script>

<style lang="scss">
@font-face {
  font-family: "HongKong";
  src: local("HongKong"),
    url("../src/assets/HongKong-Medium.otf") format("opentype");
}
body {
  margin: 0px;
  height: 100vh;
  width: 100vw;
  background-color: #1c1c1c;
}
.bc {
  height: 100vh;
  width: 100vw;
  font-family: "HongKong";
  font-size: 2em;
  color: #d4d4d2;
  display: flex;
  justify-content: center;
}
</style>
