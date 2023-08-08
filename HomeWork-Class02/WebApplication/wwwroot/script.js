function getAllUsers() {
  fetch("/api/user")
    .then((response) => response.json())
    .then((data) => {
      const userList = document.getElementById("users");
      userList.innerHTML = "";
      data.forEach((user) => {
        const li = document.createElement("li");
        li.textContent = user;
        userList.appendChild(li);
      });
    });
}
k
function getUser() {
    const userId = document.getElementById("userId").value;
    fetch(`/api/user/${userId}`)
        .then((response) => response.text()) 
        .then((data) => {
            document.getElementById("singleUser").textContent = data;
        });
}


