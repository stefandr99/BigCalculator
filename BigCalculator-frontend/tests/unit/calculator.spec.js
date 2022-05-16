import { shallowMount,mount } from '@vue/test-utils'
import Calculator from '@/components/Calculator.vue'

describe('Calculator', () => {
    it('has data', () => {
      expect(typeof Calculator.data).toBe('function')
    })

    it('on press number button on page adds an element', () => {
        const wrapper = mount(Calculator)
        wrapper.find('.bc__body__number-buttons__button').trigger('click')
        expect(wrapper.vm.charRow.length).toBe(1)
    })

    it('on add operation without number should not work', () => {

        const wrapper = mount(Calculator)
        wrapper.find('.bc__body__operation-buttons .bc__body__number-buttons__button').trigger('click')
        expect(wrapper.vm.charRow.length).toBe(0)

    })

    it('on press key button on keyboard adds number then an operation', () => {
        const wrapper = mount(Calculator)
        wrapper.find('.bc__body__number-buttons__button').trigger('click')
        wrapper.find('.bc__body__operation-buttons .bc__body__number-buttons__button').trigger('click')
        expect(wrapper.vm.charRow.length).toBe(4)
    })

    it('10 + 6', () => {
        const wrapper = mount (Calculator)
        wrapper.findAll('.bc__body__number-buttons__button').filter(n => n.text() === '1').trigger('click')
        wrapper.findAll('.bc__body__number-buttons__button').filter(n => n.text() === '0').trigger('click')
        wrapper.findAll('.bc__body__operation-buttons .bc__body__number-buttons__button').filter(n => n.text() === '+').trigger('click')
        wrapper.findAll('.bc__body__number-buttons__button').filter(n => n.text() === '6').trigger('click')
        expect(wrapper.vm.charRow.join("")).toBe('10 + 6')
    })

})

