let username = document.querySelector("#username");
let password = document.querySelector("#password");
let loginBtn = document.querySelector("#sign_in");

let getUser = localStorage.getItem("username");
let getPassword = localStorage.getItem("password");

loginBtn.addEventListener("click", function(e) {
    e.preventDefault();
    if (username.value === "" || password.value === "") {
        alert("Please Fill Data");
    }
    else{
       if ((getUser && getUser.trim() === username.value.trim() )&&(getPassword && getPassword === password.value)){
        setTimeout(()=>{
            window.location="main.html";
         } ,1500);
       }
       else{
        alert("Please Fill Correct Data");

       }
    }
});
