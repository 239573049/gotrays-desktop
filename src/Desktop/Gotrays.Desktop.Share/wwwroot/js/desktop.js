function click(id){
    const dom = document.getElementById(id);
    if(dom){
        dom.click()
    }else {
        console.log('dom not found')        
    }
}

export {
    click
}