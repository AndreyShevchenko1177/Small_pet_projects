
function strip(x: string | number) {
    if (typeof x == 'number') {
        return x.toFixed()
    }

    return x.trim();
}

class MyResponse {
    header = 'res header'
    result = 'res result'

}
class MyError {
    header = 'error header'
    message = 'error message'
}

function handle (res: MyResponse | MyError) {
    if (res instanceof MyResponse) {
        return {
            info: res.header +res.result
        }
    } else {
        return {
            info: res.header + res.message
        }
    }
}

// =========================


type AlertType = 'sucsess' | 'danger' | 'warning'

function setAlertType (type: AlertType) {
    // .........
}

setAlertType('danger')
setAlertType('warning')
//setAlertType('hren')