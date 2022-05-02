<template>
  <div class="bc-basic-calculator">
    <div v-if="advanced === false" class="bc__body">
      <div class="bc__body__display">
        <div
          class="results_advanced"
          @click="advanced = true"
          v-if="JSON.stringify(result) !== JSON.stringify({})"
        >
          View operations
        </div>
        <div class="bc__body__display__value">
          {{ charRow.join("").length === 0 ? "0" : charRow.join("") }}
        </div>
        <div id="display-history"></div>
      </div>
      <div class="bc__body__buttons">
        <div class="bc__body__number-buttons">
          <number-button
            v-for="(button, index) in numbers"
            :key="index"
            :text="button"
            @addedCharacter="addCharacter"
          ></number-button>
          <button @click="getResult()" class="bc__body__number-buttons__equals">
            =
          </button>
        </div>
        <div class="bc__body__operation-buttons">
          <operation-button
            v-for="(button, index) in operations"
            :key="index"
            :text="button"
            @addedOperation="addOperation"
          ></operation-button>
        </div>
      </div>
    </div>
    <div v-if="advanced === true">
      <ExpressionResult
        :expression="data.expression"
        :keys="basicKeys"
        :result="result"
      ></ExpressionResult>
    </div>
  </div>
</template>

<script>
import NumberButton from "../components/NumberButton.vue";
import OperationButton from "../components/OperationButton.vue";

import { Report } from "notiflix/build/notiflix-report-aio";
import axios from "axios";
import ExpressionResult from "./ExpressionResult.vue";
export default {
  name: "App",
  components: {
    NumberButton,
    OperationButton,
    ExpressionResult,
  },
  data() {
    return {
      advanced: false,
      charRow: [],
      parenthesesCount: 0,
      numbers: ["7", "8", "9", "4", "5", "6", "1", "2", "3", "0", "del"],
      operations: ["+", "-", "*", "/", "(", ")", "^", "√"],
      basicKeys: {},
      result: {},
      data: { expression: "", terms: [] },
    };
  },
  methods: {
    addCharacter(text) {
      if (text == ".") {
        Report.info(
          "Only integer numbers are allowed",
          '"." is not allowed',
          "Continue"
        );
      } else if (text == "del") {
        this.charRow.pop();
      } else {
        if (
          this.charRow[this.charRow.length - 1] == " " &&
          this.charRow[this.charRow.length - 2] == ")"
        ) {
          Report.info("Not allowed", "Insert a number first", "Continue");
        } else {
          this.charRow.push(text);
        }
      }
    },
    addOperation(text) {
      console.log(this.charRow[this.charRow.length - 1]);
      if (text == "(") {
        if (this.charRow.length == 0) {
          this.charRow.push(...[" ", text, " "]);
          this.parenthesesCount++;
        } else if (/\d/.test(this.charRow[this.charRow.length - 1])) {
          Report.info(
            "Only integer numbers are allowed",
            '"." is not allowed',
            "Continue"
          );
        } else {
          this.charRow.push(...[" ", text, " "]);
          this.parenthesesCount++;
        }
      } else if (text == ")") {
        if (this.parenthesesCount <= 0) {
          Report.info(
            "Parentheses are not balanced",
            '"(" is not balanced',
            "Continue"
          );
        } else if (!/\d|[)]/.test(this.charRow[this.charRow.length - 1])) {
          Report.info(
            "Please insert an number before closing parentheses",
            '")" is not allowed',
            "Continue"
          );
        } else {
          this.charRow.push(...[" ", text, " "]);
          this.parenthesesCount--;
        }
      } else {
        if (
          !/\d|[)]/.test(this.charRow[this.charRow.length - 1]) &&
          !/[)]/.test(this.charRow[this.charRow.length - 2])
        ) {
          Report.info(
            "Please insert an number before adding operation",
            "Those are the rules",
            "Continue"
          );
        } else {
          this.charRow.push(...[" ", text, " "]);
        }
      }
    },
    getResult() {
      if (this.charRow.length == 0) {
        Report.info(
          "Please insert an number",
          "Those are the rules",
          "Continue"
        );
      } else {
        let n = 0;
        let newExpression = "";
        this.charRow
          .join("")
          .split(" ")
          .forEach((e) => {
            if (e !== " " && /\d/.test(e)) {
              if (!this.basicKeys[e]) {
                this.basicKeys[e] = String.fromCharCode(97 + n);
                n++;
              }
              newExpression += this.basicKeys[e];
            } else if (e !== " ") {
              newExpression += e;
            }
          });

        this.data.expression = newExpression;
        for (const [key, value] of Object.entries(this.basicKeys)) {
          this.data.terms.push({
            name: value,
            value: key,
          });
        }
        axios
          .post("http://localhost:5187/Validate", this.data)
          .then((response) => {
            console.log(response.data);
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

        axios
          .post("http://localhost:5187/Compute", this.data)
          .then((response) => {
            console.log(response.data);
            this.charRow = [response.data["final result"]];
            this.result = response.data;
          })
          .catch((response) => {
            Report.failure(
              "Error",
              "" + response.response.data[0],
              "Try again"
            );
          });
      }
    },
    removeCharacter() {
      this.charRow.pop();
    },
  },
};
</script>

<style lang="scss">
@font-face {
  font-family: "HongKong";
  src: local("HongKong"),
    url("../assets/HongKong-Medium.otf") format("opentype");
}
.bc {
  &__body {
    display: flex;
    align-content: center;
    justify-content: center;
    flex-direction: column;
    width: 800px;
    max-width: 1000px;
    &__value {
    }
    &__display {
      display: flex;
      justify-content: space-between;
      width: 100%;
      align-items: center;
      &__value {
        justify-self: flex-end;
        display: flex;
        width: 100%;
        justify-content: flex-end;
      }
    }
    &__buttons {
      width: 100%;
      display: flex;
      flex-grow: 1;
    }
    &__number-buttons {
      height: 699px;
      max-width: 65%;
      display: flex;
      justify-content: center;
      flex-wrap: wrap;
      flex-grow: 1;
      &__equals {
        all: unset;
        cursor: pointer;
        width: 25%;
        font-size: 0.9em;
        font-weight: 700;
        color: black;
        background-color: rgb(145, 37, 37);
        border-radius: 16px;
        margin: 12px;
        display: flex;
        justify-content: center;
        align-items: center;
      }
    }
    &__operation-buttons {
      height: 750px;
      flex-grow: 1;
      width: 35%;
      max-width: 35%;
      display: flex;
      flex-direction: column;
      justify-content: start;
      flex-wrap: wrap;
    }
  }
}
</style>
