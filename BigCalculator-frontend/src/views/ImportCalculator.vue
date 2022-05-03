<template>
  <div class="bc-import">
    <div v-if="JSON.stringify(result) == JSON.stringify({})">
      <div class="es-page-header">
        <router-link class="nav" to="/"><button>home</button></router-link>
        <h3>Import Calculator</h3>
      </div>

      <input id="importxml" type="file" @change="loadTextFromFile" hidden />
      <label class="bc-import-field" for="importxml">choose a xml</label>
      <br />
    </div>
    <div v-else>
      <ExpressionResult :result="result"></ExpressionResult>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import ExpressionResult from "@/components/ExpressionResult.vue";
export default {
  components: { ExpressionResult },
  data() {
    return {
      result: {},
      message: "",
    };
  },
  methods: {
    loadTextFromFile(ev) {
      const file = ev.target.files[0];
      const reader = new FileReader();

      reader.onload = (e) => this.uploadFile(e.target.result);
      reader.readAsText(file);
    },
    uploadFile(xmlBodyStr) {
      var config = {
        headers: { "Content-Type": "text/xml" },
      };

      axios
        .post("http://localhost:5187/ComputeXml", xmlBodyStr, config)
        .then((response) => {
          this.result = response.data;
        });
    },
  },
};
</script>

<style lang="scss" scoped>
.bc-import {
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
.bc-import-field {
  all: unset;
  cursor: pointer;
  margin: 12px;
  padding: 12px 24px;
  border-radius: 16px;
  background-color: #505050;
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
