HTMLCollection.prototype.forEach = function(callback){
    for(let i = 0; i < this.length; i++){
        callback(this[i], i);
    }
};

let productArticles = document.getElementsByClassName("product-item");
let coverItems = document.getElementsByClassName("cover-item");

/*
productArticles.forEach(article => {
    let prodId = article.getAttribute("data-prod-id");

    article.addEventListener("click", function(){
        window.open(`article.html?id=${prodId}`, "_self");
    });
});*/

// Navigation

let navButton = document.getElementById("nav-button");
navButton.addEventListener("click", function(){
    let nav = document.getElementById("nav");
    nav.classList.contains("nav--open")
        ? nav.classList.remove("nav--open")
        : nav.classList.add("nav--open");
});

// Cover

let cover = document.getElementById("cover");
let controlRight = cover.children[cover.children.length - 1];
let controlLeft = cover.children[cover.children.length - 2];

let autoCoverInterval;

let onChangeSelected = function(){
    let coverLength = cover.children.length - 2;

    let selectedIndex = -1;
    cover.children.forEach((item, index) => {
        if(item.classList.contains("cover-item--selected"))
        {
            selectedIndex = index;
            item.classList.remove("cover-item--selected");
        }
    });

    let nextIndex = 0
    if(this.valueOf()){
        if((selectedIndex + 1) < coverLength) nextIndex = selectedIndex + 1;
        
    } else {
        if(selectedIndex - 1 >= 0) nextIndex = selectedIndex - 1;
        else nextIndex = coverLength - 1;
    }

    cover.children[nextIndex].classList.add("cover-item--selected");
    clearInterval(autoCoverInterval);
    autoCoverInterval = setInterval(onChangeSelected.bind(true), 5000);
}

autoCoverInterval = setInterval(onChangeSelected.bind(true), 5000);

controlLeft.addEventListener("click", onChangeSelected.bind(false));
controlRight.addEventListener("click", onChangeSelected.bind(true));