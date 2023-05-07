"use strict";

document.addEventListener("DOMContentLoaded", function () {

  // Query for necessary elements
  const modal = document.querySelector(".welcome-modal");
  const overlay = document.querySelector(".overlay");
  const btnCloseModal = document.querySelector(".close-modal");
  const modalContent = document.getElementById("modal-content");

  // Define function for closing modal
  const closeModal = function () {
    modal.classList.add("hidden");
    overlay.classList.add("hidden");
  };

  // Check if there is a message in temp data container
  if (modalContent.innerText !== "") {

    // Display modal and overlay
    modal.classList.remove("hidden");
    overlay.classList.remove("hidden");

    btnCloseModal.addEventListener("click", closeModal);
    overlay.addEventListener("click", closeModal);

    document.addEventListener("keydown", function (e) {
      if (e.key === "Escape" && !modal.classList.contains("hidden")) {
        closeModal();
      }
    });
    
    // Open modal
    modal.classList.remove("hidden");
    overlay.classList.remove("hidden");
  }
});