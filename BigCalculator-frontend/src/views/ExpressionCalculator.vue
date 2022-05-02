<template>
  <div class="bc-expression">
    <h3>Expression Calculator</h3>
    <h6 v-if="step === 1">enter an expression</h6>
    <h6 v-if="step === 2">enter the values of the variables</h6>
    <Expression :data="data" v-if="step === 1" />
    <ExpressionValues v-if="step === 2" :keys="keys"></ExpressionValues>
    <ExpressionResult
      v-if="step === 3"
      :expression="data.expression"
      :keys="keys"
      :result="result"
    ></ExpressionResult>

    <div v-if="step === 1" class="bc-expression__buttons">
      <router-link class="nav" to="/"><button>back</button></router-link>
      <button @click="nextStep()">next</button>
    </div>
    <div v-if="step === 2" class="bc-expression__buttons">
      <button @click="prevStep">back</button>
      <button @click="nextStep()">finish</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { Report } from "notiflix/build/notiflix-report-aio";
import { Block } from "notiflix/build/notiflix-block-aio";

import Expression from "@/components/Expression.vue";
import ExpressionValues from "@/components/ExpressionValues.vue";
import ExpressionResult from "@/components/ExpressionResult.vue";

export default {
  name: "ExpressionCalculator",
  components: {
    Expression,
    ExpressionValues,
    ExpressionResult,
  },
  data() {
    return {
      step: 1,
      data: {
        expression: "",
        terms: [],
      },
      keys: {},
      result: {},
    };
  },
  methods: {
    nextStep() {
      if (this.step === 1) {
        Block.dots(".bc-expression__field");
        this.keys = {};

        if (/\d/.test(this.data.expression)) {
          Block.remove(".bc-expression__field");
          Report.failure(
            "Error",
            "Expression must not contain numbers",
            "Close"
          );
          return;
        }

        this.data.expression.split("").forEach((element) => {
          if (/[a-zA-Z]/.test(element) && !this.keys[element]) {
            this.keys[element] = 1;
            this.data.terms.push({
              name: element,
              value: "1",
            });
          }
        });

        axios
          .post("http://localhost:5187/Validate", this.data)
          .then((response) => {
            console.log(response.data);
            Block.remove(".bc-expression__field");
            this.step++;
          })
          .catch((response) => {
            console.log(response.response.data[0]);
            Block.remove(".bc-expression__field");
            Report.failure(
              "Error",
              "" + response.response.data[0],
              "Try again"
            );
          });
      } else if (this.step === 2) {
        Block.dots(".bc-expression-pairs");

        this.data.terms.forEach((element) => {
          element.value = this.keys[element.name];
          element.value = element.value.toString();
        });
        console.log(this.data);
        axios
          .post("http://localhost:5187/Compute", this.data)
          .then((response) => {
            Block.remove(".bc-expression-pairs");
            this.result = response.data;
            console.log(this.result);
            this.step++;
          })
          .catch((response) => {
            console.log(response.response.data[0]);
            Block.remove(".bc-expression-pairs");
            Report.failure(
              "Error",
              "" + response.response.data[0],
              "Try again"
            );
          });
      }
    },
    prevStep() {
      if (this.step === 2) {
        this.data.terms = [];
        this.keys = {};
        this.step--;
      }
    },
  },
};
</script>

<style lang="scss" scoped>
h3 {
  margin-bottom: 24px;
  color: #ff9500;
}
h6 {
  font-weight: 400;
  color: #ff9500;
  margin-top: 0px;
}
.bc-expression {
  display: flex;
  flex-direction: column;
  align-items: center;
  &__buttons {
    display: flex;
    justify-content: space-evenly;
    width: 100%;
    margin-top: 30px;
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
</style>
