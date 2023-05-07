"use strict";

document.addEventListener("DOMContentLoaded", function () {
  const modal = document.querySelector(".welcome-modal");
  const overlay = document.querySelector(".overlay");
  const btnCloseModal = document.querySelector(".close-modal");
  const modalContent = document.getElementById("modal-content");

  if (modalContent.innerText !== "") {
    modal.classList.remove("hidden");
    overlay.classList.remove("hidden");

    btnCloseModal.addEventListener("click", closeModal);
    overlay.addEventListener("click", closeModal);

    document.addEventListener("keydown", function (e) {
      if (e.key === "Escape" && !modal.classList.contains("hidden")) {
        closeModal();
      }
    });

    openModal();
  }
});

const openModal = function () {
  modal.classList.remove("hidden");
  overlay.classList.remove("hidden");
};

const closeModal = function () {
  modal.classList.add("hidden");
  overlay.classList.add("hidden");
};
