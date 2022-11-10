export interface IFooter extends React.ComponentPropsWithoutRef<'footer'> {}

const Footer: React.FC<IFooter> = ({ className, ...footerProps }) => {
  return (
    <footer>
      <a
        href="https://cryptoways.com"
        target="_blank"
        rel="noopener noreferrer"
      >
        Powered by{' '}
        <img
          src="/cryptowaysFooterLogo.svg"
          alt="CryptoWays"
          className="logo"
        />
      </a>
    </footer>
  );
};

export default Footer;
