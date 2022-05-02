<template>
  <div class="es-result">
    <div class="es-result-operation-description">{{ expression }}</div>
    <hr />
    <div class="es-result-pairs">
      <div
        class="es-result-pair"
        v-for="(item, key, index) in keys"
        :key="index"
      >
        {{ key }} = {{ keys[key] }}
      </div>
    </div>
    <hr />
    <div class="es-result-operations">
      <div v-for="(item, key, index) in result" :key="index">
        <div
          class="es-result-operation-pair"
          v-if="key.split(' ')[0] == 'operation'"
        >
          <div class="es-result-operation-order">
            Operation {{ key.split(" ")[1] }}
          </div>
          :
          <div class="es-result-operation-description">
            {{ item }}
          </div>
        </div>
      </div>
    </div>
    <hr />
    <div class="es-result-operations-final">
      {{ result["final result"] }}
    </div>
  </div>
</template>

<script>
export default {
  name: "ExpressionResult",
  props: {
    expression: {
      type: String,
    },
    keys: {
      type: Object,
    },
    result: {
      type: Object,
    },
  },
};
</script>

<style lang="scss" scoped>
.es-result {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
.es-result-pairs {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
}
hr {
  width: 100%;
  height: 1px;
  border: none;
  background-color: #505050;
  margin-top: 20px;
  margin-bottom: 20px;
}
.es-result-pair {
  padding: 18px;
  margin: 8px;
  background: #505050;
  color: #d4d4d2;
  border-radius: 8px;
}
.es-result-operation-pair {
  display: flex;
  align-items: center;
  justify-content: center;
}
.es-result-operation-order {
  padding: 18px;
  margin: 8px;
  background: #505050;
  color: #d4d4d2;
  border-radius: 8px;
}
.es-result-operation-description {
  padding: 18px;
  margin: 8px;
  background: #505050;
  color: #d4d4d2;
  border-radius: 8px;
}
.es-result-operations-final {
  padding: 24px 64px;
  font-size: 48px;
  margin: 8px;
  background: #ff9500;
  color: white;
  border-radius: 8px;
}
</style>
