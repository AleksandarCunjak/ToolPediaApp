import React from 'react';
import './Footer.css'; // Stilovi za footer
import Newsletter from '../Newsletter/Newsletter';

const Footer = () => {
  return (
    <footer className="footer">
      {/* Prva trećina footera */}
      <div className="footer-column">
        <Newsletter />
      </div>

      {/* Preostale dvije trećine footera */}
      <div className="footer-column">
        <div className="footer-logo">
          <img src="/images/logo.png" alt="Logo" />
        </div>
        <div className="social-icons">
          <a href="link-ka-facebooku"><i className="fab fa-facebook"></i></a>
          <a href="link-ka-twitteru"><i className="fab fa-twitter"></i></a>
          <a href="link-ka-instagramu"><i className="fab fa-instagram"></i></a>
        </div>
      </div>
      <div className="footer-column">
        <div className="legal-pages">
          <a href="/privacy-policy">Privacy Policy</a>
          <a href="/terms-of-service">Terms of Service</a>
          <a href="/cookie-policy">Cookie Policy</a>
        </div>
      </div>
      <div className="footer-column">
        <div className="contact-info">
          <p>Contact Us</p>
          <p>Phone: +1234567890</p>
          <p>Address: 123 Main St, City, Country</p>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
