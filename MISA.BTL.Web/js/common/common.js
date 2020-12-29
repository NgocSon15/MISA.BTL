/**
 * Format dữ liệu ngày tháng sang ngày/tháng/năm
 * @param {any} date tham số có kiểu dữ liệu bất kỳ
 * CreatedBy: NNSON (29/12/2020)
 */
function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return "";
    }
    else {
        var day = date.getDate();
        if (day < 10) day = '0' + day;
        var month = date.getMonth() + 1;
        if (month < 10) month = '0' + month;
        var year = date.getFullYear();
        return day + '/' + month + '/' + year;
    }
}

/**
 * Hàm định dạng hiển thị tiền tệ
 * @param {Number} money Số tiền
 * CreatedBy: NNSON (29/12/2020)
 */
function formatMoney(money) {
    if (money == null) {
        return "";
    } else {
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
        return num;
    }
}