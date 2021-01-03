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

function formatDate2(date) {
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
        return year + '-' + month + '-' + month;
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
        var num = money.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
        return num;
    }
}

function getGenderName(genderCode) {
    if (genderCode == 0) {
        return "Nam";
    }
    else if (genderCode == 1) {
        return "Nữ";
    }
    else
    {
        return "Khác";
    }
}

function getWorkStatusName(statusCode) {
    if (statusCode == 0) {
        return "Đang làm việc";
    }
    else if (statusCode == 1) {
        return "Đang thử việc";
    }
    else if (statusCode == 2) {
        return "Đã nghỉ việc";
    }
    else
    {
        return "Đã nghỉ hưu";
    }
}
