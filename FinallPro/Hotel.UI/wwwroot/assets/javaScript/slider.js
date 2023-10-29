const btns = document.querySelectorAll(".nav-btn")
        const slides = document.querySelectorAll(".video-slider")
        var sliderNav = function(manual){
            btns.forEach((btn)=>{
                btn.classList.remove("active")
            });

            slides.forEach((slide)=>{
                slide.classList.remove("active")
            });

            btns[manual].classList.add("active");
            slides[manual].classList.add("active");
        }
        btns.forEach((btn,i)=>{
            btn.addEventListener("click",() =>{
                sliderNav(i);
            });
        });

        //aos
        AOS.init({
        duration: 1000, // Animasyon süresi (milisaniye cinsinden)
        easing: 'ease-in-out', // Animasyon eğrisi
        once: true // Animasyonlar sadece bir kez çalışsın mı?
    });

    //sliderjs
    const wrapper = document.querySelector(".wrapper");
const carousel = document.querySelector(".carousel");
const firstCardWidth = carousel.querySelector(".card").offsetWidth;
const arrowBtns = document.querySelectorAll(".wrapper i");
const carouselChildrens = [...carousel.children];
let isDragging = false, isAutoPlay = true, startX, startScrollLeft, timeoutId;
// Get the number of cards that can fit in the carousel at once
let cardPerView = Math.round(carousel.offsetWidth / firstCardWidth);
// Insert copies of the last few cards to beginning of carousel for infinite scrolling
carouselChildrens.slice(-cardPerView).reverse().forEach(card => {
    carousel.insertAdjacentHTML("afterbegin", card.outerHTML);
});
// Insert copies of the first few cards to end of carousel for infinite scrolling
carouselChildrens.slice(0, cardPerView).forEach(card => {
    carousel.insertAdjacentHTML("beforeend", card.outerHTML);
});
// Scroll the carousel at appropriate postition to hide first few duplicate cards on Firefox
carousel.classList.add("no-transition");
carousel.scrollLeft = carousel.offsetWidth;
carousel.classList.remove("no-transition");
// Add event listeners for the arrow buttons to scroll the carousel left and right
arrowBtns.forEach(btn => {
    btn.addEventListener("click", () => {
        carousel.scrollLeft += btn.id == "left" ? -firstCardWidth : firstCardWidth;
    });
});
const dragStart = (e) => {
    isDragging = true;
    carousel.classList.add("dragging");
    // Records the initial cursor and scroll position of the carousel
    startX = e.pageX;
    startScrollLeft = carousel.scrollLeft;
}
const dragging = (e) => {
    if(!isDragging) return; // if isDragging is false return from here
    // Updates the scroll position of the carousel based on the cursor movement
    carousel.scrollLeft = startScrollLeft - (e.pageX - startX);
}
const dragStop = () => {
    isDragging = false;
    carousel.classList.remove("dragging");
}
const infiniteScroll = () => {
    // If the carousel is at the beginning, scroll to the end
    if(carousel.scrollLeft === 0) {
        carousel.classList.add("no-transition");
        carousel.scrollLeft = carousel.scrollWidth - (2 * carousel.offsetWidth);
        carousel.classList.remove("no-transition");
    }
    // If the carousel is at the end, scroll to the beginning
    else if(Math.ceil(carousel.scrollLeft) === carousel.scrollWidth - carousel.offsetWidth) {
        carousel.classList.add("no-transition");
        carousel.scrollLeft = carousel.offsetWidth;
        carousel.classList.remove("no-transition");
    }
    // Clear existing timeout & start autoplay if mouse is not hovering over carousel
    clearTimeout(timeoutId);
    if(!wrapper.matches(":hover")) autoPlay();
}
const autoPlay = () => {
    if(window.innerWidth < 800 || !isAutoPlay) return; // Return if window is smaller than 800 or isAutoPlay is false
    // Autoplay the carousel after every 2500 ms
    timeoutId = setTimeout(() => carousel.scrollLeft += firstCardWidth, 2500);
}
autoPlay();
carousel.addEventListener("mousedown", dragStart);
carousel.addEventListener("mousemove", dragging);
document.addEventListener("mouseup", dragStop);
carousel.addEventListener("scroll", infiniteScroll);
wrapper.addEventListener("mouseenter", () => clearTimeout(timeoutId));
wrapper.addEventListener("mouseleave", autoPlay);

//makereservation
// Generate a random price
function generateRandomPrice() {
    const minPrice = 100; // Minimum price
    const maxPrice = 500; // Maximum price
    return Math.floor(Math.random() * (maxPrice - minPrice + 1)) + minPrice;
}

// Countdown duration (in seconds)
const countdownDuration = 60;

// Countdown start time
let countdownStart = null;

// Start the countdown
function startCountdown() {
    countdownStart = Date.now();
    updateCountdown();

    const countdownInterval = setInterval(() => {
        const elapsedTime = (Date.now() - countdownStart) / 1000;
        const remainingTime = countdownDuration - elapsedTime;

        if (remainingTime <= 0) {
            clearInterval(countdownInterval);
            // Reload the page
            location.reload();
        } else {
            updateCountdown();
        }
    }, 1000);
}

// Update the countdown
function updateCountdown() {
    const remainingTime = countdownDuration - (Date.now() - countdownStart) / 1000;
    const minutes = Math.floor(remainingTime / 60);
    const seconds = Math.floor(remainingTime % 60);

    const countdownElement = document.getElementById("countdown");
    countdownElement.textContent = `${minutes}:${seconds < 10 ? "0" : ""}${seconds}`;
}

// Select necessary elements from HTML
const reservationSection = document.getElementById("reservation");
const openReservationButton = document.getElementById("reservationBtn");
const closeReservationButton = document.getElementById("closeBtn");
const reservationForm = document.getElementById("reservation-form");
const reservationResult = document.getElementById("reservationResult");
const confirmReservationButton = document.getElementById("confirmReservation");
const cancelReservationButton = document.getElementById("cancelReservation");
const countdownElement = document.getElementById("countdown");

// Hide the reservation panel
reservationSection.style.display = "none";
reservationResult.style.display = "none";

// Show the reservation panel when the "Make a Reservation" button is clicked
openReservationButton.addEventListener("click", function () {
    reservationSection.style.display = "block";
});

// Hide the reservation panel when the close button is clicked
closeReservationButton.addEventListener("click", function () {
    reservationSection.style.display = "none";
});

// Prevent page refresh when the form is submitted (example)
reservationForm.addEventListener("submit", function (event) {
    event.preventDefault();
    reservationResult.style.display = "block";

    // Generate a random price
    const randomPrice = generateRandomPrice();
    const priceElement = document.getElementById("price");
    priceElement.textContent = `$${randomPrice}`;

    // Start the countdown
    startCountdown();
});

// Perform actions when reservation is confirmed
confirmReservationButton.addEventListener("click", function () {
    // You can perform price calculation or other actions here
    alert("Your reservation has been confirmed!");
    reservationResult.style.display = "none";
    reservationSection.style.display = "none";
});

// Cancel the reservation
cancelReservationButton.addEventListener("click", function () {
    reservationResult.style.display = "none";
});
const services = document.querySelector('.service-container');
const prevBtn = document.getElementById('prevBtn');
const nextBtn = document.getElementById('nextBtn');

let currentIndex = 0;

prevBtn.addEventListener('click', () => {
    if (currentIndex > 0) {
        currentIndex--;
        updateServicesPosition();
    }
});

nextBtn.addEventListener('click', () => {
    const totalServices = document.querySelectorAll('.service').length;
    if (currentIndex < totalServices - 3) {
        currentIndex++;
        updateServicesPosition();
    }
});

function updateServicesPosition() {
    const serviceWidth = document.querySelector('.service').offsetWidth;
    const newPosition = -currentIndex * serviceWidth;
    services.style.transform = `translateX(${newPosition}px)`;
}