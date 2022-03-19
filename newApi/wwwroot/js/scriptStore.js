let userInfo = document.querySelector("#user_info");
let userDom = document.querySelector("#user");
let link = document.querySelector("#link");
let logoutBtn = document.querySelector("#logout");

let username = localStorage.getItem("username");

    if (username){
        link.remove();
        userInfo.style.display ="flex";
        userDom.innerHTML = username;
    }

logoutBtn.addEventListener("click" , function()
{
    localStorage.clear();
    setTimeout(()=>{
      window.location= "register.html";
    },1500);
})

//define product

let productsDom = document.querySelector(".products");
let cartProductDom =document.querySelector(".carts-products div");
let cartProductMenu=document.querySelector(".carts-products");
let bageDom =document.querySelector(".badge");
let shoppingCartItems=document.querySelector(".shoppingcart");

let products=[
    {
    id:1,
    title:"Tomato Product",
    quality:"A",
    imageUrl:"images3/tomato.jpg",
    price: "20$"
},

{
    id:2,
    title:"Banana Product",
    quality:"C",
    imageUrl:"images3/bananaaaa.jpg",
    price:"7$"
},

{
    id:3,
    title:"Red Onion Product",
    quality:"A",
    imageUrl:"images3/red onion.jpg",
    price:"15$"
},

{
    id:4,
    title:"Potato Product",
    quality:"B",
    imageUrl:"images3/potato.jpg",
    price:"11$"
},
];

shoppingCartItems.addEventListener("click",openCartMenu);

function drawProductsUI(){
    let productsUI =products.map( (item) => {
        return `
        <div class="product-item">
        <img 
        src="${item.imageUrl}" 
        class="product-item-img" 
        alt="image"
        />

        <div class="product-item-desc">
        <h2>${item.title}</h2>
        <p>It is a fresh product from our farm </p>
        <span>quality:${item.quality} </span>
        <span>price:${item.price} </span>
        </div>
        <div class="product-item-actions">
        <button class="add-to-cart" onclick="addedToCart(${item.id})">Add To Cart</button>
        <i class="favorite far fa-heart"></i>
        </div>
        </div>
    `;
    } );
    productsDom.innerHTML = productsUI;
}

drawProductsUI();

function addedToCart(id){
   let choosenItem = products.find( (item) => item.id === id);
   cartProductDom.innerHTML += `<p>${choosenItem.title}</p>`;
   let cartProductLength=document.querySelectorAll(".carts-products div p");
   bageDom.style.display ="block";
   bageDom.innerHTML= cartProductLength.length;
}
function checkLogedUser(){
    if (localStorage.getItem("username")){
        window.location="cartproducts.html";
    }
    else{
        window.location="login.html";
    }
}

function openCartMenu(){
    if(cartProductDom.innerHTML != ""){
        if (cartProductMenu.style.display=="block"){
            cartProductMenu.style.display="none";
        }else{    cartProductMenu.style.display="block";
    }

    }
}