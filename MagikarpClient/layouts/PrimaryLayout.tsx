import Head from 'next/head';
import Footer from '../components/Footer';

export interface IPrimaryLayout extends React.ComponentPropsWithoutRef<'div'> {
  justify?: 'items-center' | 'items-start';
}

const PrimaryLayout: React.FC<IPrimaryLayout> = ({ children, ...divProps }) => {
  return (
    <div>
      <Head>
        <title>Magikarp</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <div {...divProps} className={'container'}>
        <main>{children}</main>
        <Footer />
      </div>
    </div>
  );
};

export default PrimaryLayout;
