
//Register user
let register_user = document.querySelector("#register_user");
let email = document.querySelector("#email");
let phone =document.querySelector("#phone");
let register_password = document.querySelector("#register_password");

let register_btn = document.querySelector("#sign_up");

register_btn.addEventListener("click", function (e) {
        e.preventDefault();
        if (register_user.value === "" || email.value === "" || phone.value === ""  || register_password.value === "") {
            alert("Please Fill Data");
        }
        else{
            localStorage.setItem("username",register_user.value);
            localStorage.setItem("email",email.value);
            localStorage.setItem("phone",phone.value);
            localStorage.setItem("password",register_password.value);

            setTimeout(()=>{
                container.classList.remove("sign-up-mode");
                 } ,1500);

        }
    });



/* login_user*/

let login_user = document.querySelector("#login_user");
let login_password = document.querySelector("#login_password");
let loginBtn = document.querySelector("#sign_in");

let getUser = localStorage.getItem("login_user");
let getPassword = localStorage.getItem("login_password");

loginBtn.addEventListener("click", function(e) {
    e.preventDefault();
    if (login_user.value === "" || login_password.value === "") {
        alert("Please Fill Data");
    }
    else{
       if((getUser && getUser.trim() === register_user.value.trim() )&&(getPassword && getPassword === register_password.value)){
        setTimeout(()=>{
            window.location="main.html";
         } ,1500);
       }
       else{
        alert("Please Fill Correct Data");

       }
    }
});



/* التحويل من sign_inللsign_up*/ 
const sign_in_btn = document.querySelector("#sign-in-btn");
const sign_up_btn = document.querySelector("#sign-up-btn");
const container = document.querySelector(".container");

sign_up_btn.addEventListener("click", () => {
  container.classList.add("sign-up-mode");
});

sign_in_btn.addEventListener("click", () => {
  container.classList.remove("sign-up-mode");
});


