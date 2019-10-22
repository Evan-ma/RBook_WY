function getFunction(id) {
 
    switch (id) {
        case "0101":
            layer.msg(id);
            addsyglwindows()
            break;
        case "0102":
                layer.msg(id, function () {
                    //关闭后的操作
                });
            break;
        case "0201":
                layer.msg(id, { icon: 5 });
            break;
        case "0202":
                layer.msg(id, { icon: 2 });
            break;
    }
}