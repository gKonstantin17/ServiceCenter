<template>
  <section class="promo">
    <div class="promo_background">
      <h1>Сервисный центр Отклик</h1>
      <h3>Всегда на связи с вами</h3>
    </div>
  </section>
  <section class="about">
    <h2 class="title">О нас</h2>

    <p>
      Сервисный центр "Отклик" - это команда профессионалов, оказывающих качественные услуги по
      ремонту и обслуживанию бытовой техники, электроники и компьютерной техники.
    </p>
    <p>
      Мы работаем на рынке уже более 10 лет и за это время зарекомендовали себя как надежный и
      ответственный партнер для наших клиентов. Наши специалисты имеют большой опыт в ремонте
      различной техники, от простых бытовых приборов до сложных компьютеров и ноутбуков.
    </p>
    <p>
      Мы используем только высококачественные запчасти и оборудование, что гарантирует нашим
      клиентам надежный и долговечный ремонт.
    </p>
    <p>Наши преимущества:</p>
    <ul>
      <li>Бесплатная диагностика</li>
      <li>Гарантия на все виды работ</li>
      <li>Приветливый и профессиональный персонал</li>
    </ul>
    <p>
      Мы ценим каждого клиента и стремимся сделать все возможное, чтобы вы остались довольны нашим
      сервисом. Обращайтесь в сервисный центр "Отклик" - мы всегда готовы помочь!
    </p>
  </section>
  <section class="service">
    <h2 class="title">Наши услуги:</h2>
    <div class="service_card service_one">
      <img src="../assets/img/home/service_icon1.png" alt="service_icon" />
      <p class="service_card_title">Любой вид ремонта электроники и бытовой техники</p>
      <p class="service_card_text">
        Диагностика и ремонт смартфонов, планшетов, ноутбуков и компьютеров
      </p>
      <p class="service_card_text">
        Устранение неисправностей в телевизорах, холодильниках, стиральных машинах и другой бытовой
        технике
      </p>
      <p class="service_card_text">
        Ремонт разбитых экранов, замена аккумуляторов и разъемов питания
      </p>
    </div>
    <div class="service_card service_two">
      <img src="../assets/img/home/service_icon2.png" alt="service_icon" />
      <p class="service_card_title">Обслуживание и настройка компьютеров и мобильных устройств</p>
      <p class="service_card_text">Восстановление программного обеспечения и данных</p>
      <p class="service_card_text">
        Установка и настройка операционных систем и программного обеспечения
      </p>
      <p class="service_card_text">
        Диагностика и устранение проблем с производительностью и сбоями
      </p>
    </div>
    <div class="service_card service_free">
      <img src="../assets/img/home/service_icon3.png" alt="service_icon" />
      <p class="service_card_title">Консультация по уходу за техникой</p>
      <p class="service_card_text">
        Консультации по выбору и приобретению электроники и бытовой техники
      </p>
      <p class="service_card_text">Ответим на вопросы по обслуживанию устройств</p>
    </div>
  </section>
  <section class="contacts">
    <h2 class="title">Контакты</h2>
    <div class="contacts_info_wrapper">
      <div class="contacts_info">
        <p>Адрес сервисного центра:</p>
        <p>Рязань, ул. Гагарина, д. 123</p>
      </div>
      <div class="contacts_info">
        <p>График работы:</p>
        <p>ПН-СБ: 8:00-20:00</p>
      </div>
    </div>

    <div class="contact_links_wrapper">
      <div class="contact_wrapper">
        <img class="phone" src="../assets/img/home/contact_icon1.png" alt="contact_icon" />
        <p class="contact_info">+7-912-345-67-89</p>
      </div>
      <div class="contact_wrapper">
        <img src="../assets/img/home/contact_icon3.png" alt="contact_icon" />
        <p class="contact_info">+7-912-345-67-89</p>
      </div>
      <div class="contact_wrapper">
        <img src="../assets/img/home/contact_icon2.png" alt="contact_icon" />
        <a class="contact_info" href="#">Группа VK</a>
      </div>
    </div>
  </section>
</template>
<script></script>
<style>
.promo {
  background-image: url(../assets/img/home/promo.jpg);
  background-repeat: no-repeat;
  background-position: center center;
  background-attachment: fixed;
  background-size: cover;
  height: 650px;
  color: white;
}
.promo_background {
  width: 100%;
  height: 100%;
  z-index: -1;
  background-image: linear-gradient(140deg, rgba(0, 72, 114, 0.9) 0%, rgba(41, 17, 96, 0.8) 100%);
}
.promo h1 {
  font-size: 50px;
  font-weight: 700;
  text-align: center;
  padding-top: 25vh;
}
.promo h3 {
  font-size: 30px;
  font-weight: 700;
  text-align: center;
  padding-top: 10px;
}
.title {
  text-align: center;
  font-size: 30px;
  padding-top: 30px;
}
.about {
  width: 1140px;
  margin: 0 auto;
  padding-bottom: 30px;
}
.about p {
  text-align: justify;
  font-size: 18px;
}
.about li {
  font-size: 18px;
}
.service {
  background-color: #f8f8f8;
  padding: 0 15% 15px 15%;
}
.service_card {
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
  height: 300px;
  margin: 20px;
}
.service_card img {
  width: 64px;
  height: 64px;
  margin-top: 20px;
}
.service_card_title {
  font-size: 20px;
  font-weight: 700;
  margin-bottom: 10px;
}
.service_card_text {
  font-size: 18px;
  width: 80%;
}
.service_one {
  background-color: #ff8a3d;
  color: white;
}
.service_two {
  background-color: #fee0cb;
}
.service_free {
  background-color: #f1f1f1;
}
.contacts {
  padding: 0 15% 10% 15%;
}
.contacts p {
  font-size: 20px;
}
.contacts a {
  font-size: 20px;
}
.contacts_info_wrapper {
  display: flex;
  justify-content: space-between;
  margin-top: 30px;
  margin-bottom: 30px;
}
.contact_links_wrapper {
  display: flex;
  flex-direction: column;
}
.contact_wrapper {
  display: flex;
  margin: 0 auto;
}
.contact_wrapper img {
  width: 35px;
  height: 35px;
  margin-right: 20px;
}
.contact_wrapper .phone {
  width: 25px;
  height: 25px;
}
</style>
