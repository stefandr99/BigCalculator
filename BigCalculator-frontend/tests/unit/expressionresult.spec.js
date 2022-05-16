import { shallowMount,mount } from '@vue/test-utils'
import ExpressionResult from '@/components/ExpressionResult.vue'

describe('ExpressionResult', () => {
    let exampleData = {
        expression: 'a+b-c*d',
        keys:{
            "a": "10",
            "b": "2",
            "c": 1,
            "d": "5",
        },
        result: {
            "final result": "7",
            "operation 1": "a + b = 12",
            "operation 2": "c * d = 5",
            "operation 3": "12 - 5 = 7",
        }
}

    it('check if operation is rendered ok', () => {
        const wrapper = mount(ExpressionResult, {
            propsData: exampleData})
        expect(wrapper.find('.es-result-operation-description').text()).toBe('a+b-c*d')
    })

    it('check if number of keys is correct', () => {
        const wrapper = mount(ExpressionResult, {
            propsData: exampleData})
        expect(wrapper.findAll('.es-result-pair').length).toBe(4)
    })

    it('check key is written correctly', () => {
        const wrapper = mount(ExpressionResult, {
            propsData: exampleData})
        expect(wrapper.findAll('.es-result-pair').filter(n => n.text() === 'd = 5').length).toBe(1)
    })

    it('number of operations is correct', () => {
        const wrapper = mount(ExpressionResult, {
            propsData: exampleData})
        expect(wrapper.findAll('.es-result-operation-pair').length).toBe(3)
    })

    it('result is correct', () => {
        const wrapper = mount(ExpressionResult, {
            propsData: exampleData})
        expect(wrapper.find('.es-result-operations-final').text()).toBe('7')
    })
})