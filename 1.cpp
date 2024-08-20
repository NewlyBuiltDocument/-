#include<xstring>//提供string类
#include<vector>//提供vector类
namespace exmath{
	[[nodiscard]]constexpr size_t chshu(const std::string_view a,const char b=' ')noexcept{//字符计数
		size_t c{};
		for(char d:a)
			if(d==b) ++c;
		return c;
	}
	[[nodiscard]]constexpr size_t chshu(const std::string_view a,const size_t b,const size_t c,const char d=' ')noexcept{
		return chshu(a.substr(b,c),d);
	}
	template<typename _Ty>[[nodiscard]]constexpr _Ty pow(const _Ty& a,size_t b)noexcept{//计算exp(a,b)
		_Ty c{1};
		while(b) c*=a,--b;
		return c;}
	template<typename _Ty>[[nodiscard]]constexpr _Ty svtoty(const std::string_view a,size_t b=0,const size_t c=10)noexcept(noexcept(static_cast<_Ty>(c))
		&&std::is_nothrow_default_constructible_v<_Ty>&&noexcept((std::declval<_Ty&>()*=_Ty{})+='\0')){//字符串转数字
		_Ty d{},e{static_cast<_Ty>(c)};
		size_t f{static_cast<size_t>(-1)},g{a.size()};
		for(;b<g&&(a[b]>='0'&&a[b]<='9'||a[b]=='.');++b)
			if(a[b]=='.') f=b;
			else d*=e,d+=a[b]-'0';
		if(f!=static_cast<size_t>(-1)) d/=exmath::pow(_Ty{10},f);
		return d;
	}
	template<typename _Ty>[[nodiscard]]constexpr std::vector<_Ty> zhuan(std::string& a){//数与符号分离
		std::vector<_Ty> b{};
		std::erase(a,' ');
		for(size_t c{a.find_first_of("0123456789.")},d{a.find_first_not_of("0123456789.",c)},e{static_cast<size_t>(-1)};c!=e;){	
			b.push_back(exmath::svtoty<_Ty>(a,c));
			a.replace(c,d-c," ");
			c=a.find_first_of("0123456789.");
			d=a.find_first_not_of("0123456789.",c);}
		return b;
	}
	template<typename _Ty>constexpr void sshu(std::string& a,std::vector<_Ty>& b,const size_t c,size_t d){//无括号部分计算
		for(size_t e{a.find_first_of("+-",c)},f{a.find_first_not_of("+-",e)};e<d;e=a.find_first_of("+-",e),f=a.find_first_not_of("+-",e)){
			if(e&&a[e-1]==' '){
				++e;continue;}
			if(f>=d) break;
			b[chshu(a,0,e)]*=(chshu(a,e,f-e,'-')%2?-1:1);
			a.erase(e,f-e);
			d-=f-e;}
		for(size_t e{a.find_first_of("*/",c)},f{1};e<d;a.erase(e,2),d-=2,b.erase(b.begin()+f),e=a.find_first_of("*/",e)){
			f=chshu(a,0,e);
			if(a[e]=='*') b[f-1]*=b[f];
			else b[f-1]/=b[f];}
		for(size_t e{a.find_first_of("+-",c)},f{1};e<d;a.erase(e,2),d-=2,b.erase(b.begin()+f),e=a.find_first_of("+-",e)){
			f=chshu(a,0,e);
			if(a[e]=='+') b[f-1]+=b[f];
			else b[f-1]-=b[f];}
	}
	template<typename _Ty>[[nodiscard]]constexpr _Ty calculate(const std::string_view a){//核心计算，对括号处理
		std::string b{a};
		std::vector<_Ty> c{exmath::zhuan<_Ty>(b)};
		for(size_t d{b.find(')')},e{},f{},g{static_cast<size_t>(-1)};d!=g;d=b.find(')',e)){//有括号时对括号的处理
			e=b.rfind('(',d);
			f=chshu(b,0,d);
			if(e!=g){
				exmath::sshu(b,c,e+1,d);
				b[e]=b[e+1];
				b.erase(e+1,2);
				f=chshu(b,0,e);
				if(b.size()>e&&b[e+1]==' '){
					c[f]*=c[f+1];
					b.erase(e,1);
					c.erase(c.begin()+f+1);}
				if(e&&b[e-1]==' '){
					c[f-1]*=c[f];
					b.erase(e,1);
					c.erase(c.begin()+f);}}
			else{
				if(d){
					if(b[d-1]==' '&&b[d+1]==' '){
						c[f-1]*=c[f];
						b.erase(d,2);
						c.erase(c.begin()+f);}}
				else b.erase(0,1);
				e=0;}}
		if(b.find('(')!=static_cast<size_t>(-1))
			b.erase(b.find('('),1);
		for(size_t d{b.find('(')},e{},f{static_cast<size_t>(-1)};d!=f;d=b.find('('),d==f?0:(b.erase(d,1),0))
			if(d&&b.size()>=d&&b[d-1]==' '&&b[d]==' '){
				e=chshu(b,0,d);
				c[e-1]*=c[e];
				c.erase(c.begin()+e);}
		exmath::sshu(b,c,0,b.size());
		return c[0];
	}
}
int main(){
	constexpr double a=exmath::calculate<double>("3.5*(2+3)");//类型可以为int,double，参数为字符串（字面量和存储字符串均可）
	//注意没有异常处理，错误的字符串无法合理报错
}