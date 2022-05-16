import { shallowMount,mount } from '@vue/test-utils'
import ExpressionValues from '@/components/ExpressionValues.vue'

describe('ExpressionValues', () => {
    let exampleData = {
        keys:{
            "a": "1",
            "b": "120",
        },
}

    it('check if two keys', () => {
        const wrapper = mount(ExpressionValues, {
            propsData: exampleData})
        expect(wrapper.findAll('.bc-expression-pair').length).toBe(2)
    })
    it('check if two inputs', () => {
        const wrapper = mount(ExpressionValues, {
            propsData: exampleData})
        expect(wrapper.findAll('.bc-expression-variable-input').length).toBe(2)
    })
    it('check if at least one key is "a" ', () => {
        const wrapper = mount(ExpressionValues, {
            propsData: exampleData})
        expect(wrapper.findAll('.bc-expression-variable').filter(n => n.text() === "a").length).toBe(1)
    })
    it('check if at least one key is "b" ', () => {
        const wrapper = mount(ExpressionValues, {
            propsData: exampleData})
        expect(wrapper.findAll('.bc-expression-variable').filter(n => n.text() === "b").length).toBe(1)
    })
})