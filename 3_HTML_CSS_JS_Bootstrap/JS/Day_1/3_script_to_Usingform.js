function displayWelcomeMessage() {
  let name = document.getElementById("userInput").value;

  if (name.trim() == "") {
    document.getElementById("result").innerText = "Pls Enter Name";
  } else {
    document.getElementById("result").innerText = `Welcome , ${name}`;
  }
}
