import React, { useState } from 'react';
import './Newsletter.css'; // Stilovi za Newsletter



const Newsletter = () => {
  const [email, setEmail] = useState('');
  const [isChecked, setIsChecked] = useState(false);

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
  };

  const handleCheckboxChange = () => {
    setIsChecked(!isChecked);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch('/api/newsletter', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, receivePromotions: isChecked }),
      });
      const data = await response.json();
      console.log(data.message);
      // Ovdje možete implementirati logiku za upravljanje odgovorom ako je potrebno
    } catch (error) {
      console.error('Error submitting newsletter:', error);
      // Ovdje možete implementirati logiku za upravljanje greškom ako je potrebno
    }
  };
  
  return (
    <div className="newsletter">
      <h2>Prijavite se za naš newsletter</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="email"
          placeholder="Unesite vašu e-mail adresu"
          value={email}
          onChange={handleEmailChange}
          required
        />
        <label>
          <input
            type="checkbox"
            checked={isChecked}
            onChange={handleCheckboxChange}
          />
          Želim da primam promocije
        </label>
        <button type="submit">Prijavite se</button>
      </form>
    </div>
  );
};

export default Newsletter;
