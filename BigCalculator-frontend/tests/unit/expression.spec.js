import { shallowMount,mount } from '@vue/test-utils'
import Expression from '@/components/Expression.vue'

describe('Expression', () => {

    it('check if value is rendered correctly', () => {
        const wrapper = mount(Expression, {
            propsData: {
                data: {
                    expression: "a+b/c",
                    terms: [],
                }
            }
        })
        expect(wrapper.find('.bc-expression__field__input').element.value).toBe("a+b/c")
    })
})