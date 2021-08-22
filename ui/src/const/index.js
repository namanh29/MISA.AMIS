const entity = {
    supplier: {
        value: 1,
        text: "Là nhà cung cấp"
    },
    customer  : {
        value: 0,
        text: "Là khách hàng"
    },
}
const genders = {
    male : {
        value: 1,
        text: "Nam"
    },
    female : {
        value: 0,
        text: "Nữ"
    },
    other : {
        value: 2,
        text: "Khác"
    }
}
const paginations = [
    { value: 10, text: "10 bản ghi trên 1 trang" },
    { value: 20, text: "20 bản ghi trên 1 trang" },
    { value: 30, text: "30 bản ghi trên 1 trang" },
    { value: 50, text: "50 bản ghi trên 1 trang" },
    { value: 100, text: "100 bản ghi trên 1 trang" },
]

export default {
    entity, genders, paginations
}